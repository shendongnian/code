    public async Task<ActionResult> Register(RegisterViewModel model) {
        
        //...
    
        var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
    
        var messageBody = IntroMail(callbackUrl);
    
        await UserManager.SendEmailAsync(user.Id, "Welcome Mail", messageBody);
    
        //...
    }
