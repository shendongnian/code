    //var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, true, true);
    var correctPassword = await _userManager.CheckPasswordAsync(user, model.Password);
    if (correctPassword)
    {
        var userPrincipalAsync = await _claimsFactory.CreateAsync(user);
        var tokens = new List<AuthenticationToken>
        {
            new AuthenticationToken {Name = "TEST", Value = "TEST"},
        };
        var prop = new AuthenticationProperties();
        prop.StoreTokens(tokens);
        await HttpContext.Authentication.SignInAsync("Intigriti", userPrincipalAsync, prop);
        return RedirectToAction("Portal", "Home");
    }
    //if (result.RequiresTwoFactor)
    //{
    //    return RedirectToAction(nameof(SendCode), new { ReturnUrl = returnUrl, RememberMe = model.RememberLogin });
    //}
    //if (result.IsLockedOut)
    //{
    //    _logger.LogWarning(2, "User account locked out.");
    //    return View("Lockout");
    //}
}
