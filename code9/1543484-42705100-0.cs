    // GET: /Account/ConfirmEmail
    [AllowAnonymous]
    public async Task<ActionResult> ConfirmEmailAwait(string userId)
    {
        // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
        // Send an email with this link
        string code = await UserManager.GenerateEmailConfirmationTokenAsync(userId);
        var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = userId, code = code }, protocol: Request.Url.Scheme);
        string emailHeader = "Confirm your account";
        string emailBody = "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>";
        await UserManager.SendEmailAsync(userId, emailHeader, emailBody);
        return View(userId);
    }
