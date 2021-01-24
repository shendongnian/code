    var identityResult = await userManager.PasswordValidator.ValidateAsync(account.Password);
    if (!identityResult.Succeeded)
        return SomeError(identityResult);
    // Validate the new user BEFORE creating in the database.
    identityResult = await userManager.UserValidator.ValidateAsync(appUser);
    if (!identityResult.Succeeded)
        return SomeError(identityResult);
    identityResult = await userManager.CreateAsync(appUser, account.Password);
    if (!identityResult.Succeeded)
        return SomeError(identityResult);
