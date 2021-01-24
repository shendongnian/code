    var userId = User.Identity.GetUserId();
    var model = new IndexViewModel
    {
        HasPassword = HasPassword(),
        PhoneNumber = await UserManager.GetPhoneNumberAsync(userId),
        TwoFactor = await UserManager.GetTwoFactorEnabledAsync(userId),
        Logins = await UserManager.GetLoginsAsync(userId),
        BrowserRemembered = await AuthenticationManager.TwoFactorBrowserRememberedAsync(userId),
        CurrentUser = await UserManager.FindByIdAsync(userId)
    };
    return View(model);
