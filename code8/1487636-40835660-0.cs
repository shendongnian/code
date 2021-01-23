    [HttpPost]
    [AllowAnonymous]
    public async Task<JsonResult> Register(RegisterViewModel model)
    {
      if (ModelState.IsValid)
      {
        ...
        HostingEnvironment.QueueUserWorkItem(_ =>
            _mailHelper.SendEmailAsync(user.Email, AppConfig.AccountVerifyMailSubject, WebHelper.BuildAccountVerificationEmailBody(user.UserName, verificationUrl));
      }
      ...
    }
