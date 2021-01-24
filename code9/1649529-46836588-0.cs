    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ExternalLogin(string provider, string returnUrl = null)
    {
        var props = new AuthenticationProperties()
        {
            RedirectUri = Url.Action("ExternalLoginCallback"),
            Items =
            {
                { "returnUrl", returnUrl },
                { "scheme", AccountOptions.WindowsAuthenticationSchemeName }
            }
        };
        // I only care about Windows as an external provider
        var result = await HttpContext.AuthenticateAsync(AccountOptions.WindowsAuthenticationSchemeName);
        if (result?.Principal is WindowsPrincipal wp)
        {
            var id = new ClaimsIdentity(provider);
            id.AddClaim(new Claim(JwtClaimTypes.Subject, wp.Identity.Name));
            id.AddClaim(new Claim(JwtClaimTypes.Name, wp.Identity.Name));
            await HttpContext.SignInAsync(
                IdentityServerConstants.ExternalCookieAuthenticationScheme,
                new ClaimsPrincipal(id),
                props);
            return Redirect(props.RedirectUri);
        }
        else
        {
            return Challenge(AccountOptions.WindowsAuthenticationSchemeName);
        }
    }
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> ExternalLoginCallback()
    {
        var result = await HttpContext.AuthenticateAsync(IdentityServerConstants.ExternalCookieAuthenticationScheme);
        if (result?.Succeeded != true)
        {
            throw new Exception("External authentication error");
        }
        var externalUser = result.Principal;
        var claims = externalUser.Claims.ToList();
        var userIdClaim = claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Subject);
        if (userIdClaim == null)
        {
            userIdClaim = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
        }
        if (userIdClaim == null)
        {
            throw new Exception("Unknown userid");
        }
        claims.Remove(userIdClaim);
        string provider = result.Properties.Items["scheme"];
        string userId = userIdClaim.Value;
        var additionalClaims = new List<Claim>();
        // I changed this to use Identity as a user store
        var user = await userManager.FindByNameAsync(userId);
        if (user == null)
        {
            user = new ApplicationUser
            {
                UserName = userId
            };
            var creationResult = await userManager.CreateAsync(user);
            if (!creationResult.Succeeded)
            {
                throw new Exception($"Could not create new user: {creationResult.Errors.FirstOrDefault()?.Description}");
            }
        }
        else
        {
            additionalClaims.AddRange(await userManager.GetClaimsAsync(user));
        }
        var sid = claims.FirstOrDefault(x => x.Type == JwtClaimTypes.SessionId);
        if (sid != null)
        {
            additionalClaims.Add(new Claim(JwtClaimTypes.SessionId, sid.Value));
        }
        AuthenticationProperties props = null;
        string id_token = result.Properties.GetTokenValue("id_token");
        if (id_token != null)
        {
            props = new AuthenticationProperties();
            props.StoreTokens(new[] { new AuthenticationToken { Name = "id_token", Value = id_token } });
        }
        await HttpContext.SignInAsync(user.Id, user.UserName, provider, props, additionalClaims.ToArray());
        await HttpContext.SignOutAsync(IdentityServerConstants.ExternalCookieAuthenticationScheme);
        string returnUrl = result.Properties.Items["returnUrl"];
        if (_interaction.IsValidReturnUrl(returnUrl) || Url.IsLocalUrl(returnUrl))
        {
            return Redirect(returnUrl);
        }
        return Redirect("~/");
    }
