    var user = await _userManager.FindByEmailAsync(model.Email);
    if (user != null)
    {
        // retrieve plaintext password
        var originalPassword = GetPlainTextPassword(user);
        // retrieve token
        var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
        // reset password
        var result = await _userManager.ResetPasswordAsync(user, resetToken, originalPassword);
        if (!result.Succeeded)
        {
            // handle error
        }
    }
