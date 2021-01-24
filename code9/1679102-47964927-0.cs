    var user = await _userManager.FindByEmailAsync(model.Email);
    if (user != null && !(await _userManager.HasPasswordAsync(user)))
    {
        // retrieve plaintext password
        var originalPassword = GetPlainTextPassword(user);
        var result = await _userManager.AddPasswordAsync(user, originalPassword);
        if (!result.Succeeded)
        {
            // handle error
        }
    }
