    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
            
    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, email));
    identity.AddClaim(new Claim(ClaimTypes.Name, email));
    identity.AddClaim(new Claim(ClaimTypes.Role, "User"));
    var principal = new ClaimsPrincipal(identity);
    var authProperties = new AuthenticationProperties
    {
        AllowRefresh = true,
        ExpiresUtc = DateTimeOffset.Now.AddDays(1),
        IsPersistent = true,
    };
            
    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(principal),authProperties);
    return RedirectToPage("dashboard");
