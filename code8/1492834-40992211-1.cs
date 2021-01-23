    var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);
    if (result.Succeeded)
    {
        await AddTokensToCookie(user, model.Password);
        return RedirectToLocal(returnUrl);
    }
    if (result.RequiresTwoFactor)
    {
        // Ommitted
    }
    if (result.IsLockedOut)
    {
        // Ommitted
    }
