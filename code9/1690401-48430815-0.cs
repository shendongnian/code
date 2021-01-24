    var code = await UserManager.GeneratePasswordResetTokenAsync(userId);
    var callbackUrl = Url.Action(
        "ResetPassword", 
        "Account", 
        new { UserId = user.Id, code = code }, protocol: Request.Url.Scheme);       
