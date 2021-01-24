    public async Task<IActionResult> ImpersonateUserAsync(string userName) {
        var context = HttpContext; //Property already exists in Controller
        var originalUsername = context.User.Identity.Name;
        var impersonatedUser = await _userManager.FindByNameAsync(userName);
        var impersonatedIdentity = await _userManager.CreateAsync(impersonatedUser);
        await _userManager.AddClaimAsync(impersonatedUser, new Claim("UserImpersonation", "true"));
        await _userManager.AddClaimAsync(impersonatedUser, new Claim("OriginalUsername", originalUsername));
        var authenticationManager = context.Authentication; 
        var cookie = DefaultAuthenticationTypes.ApplicationCookie;
        await authenticationManager.SignOutAsync(cookie);
        await authenticationManager.SignInAsync(cookie, impersonatedIdentity, 
            new AuthenticationProperties() { IsPersistent = false });
        return RedirectToAction("Index", "Home");
    }
