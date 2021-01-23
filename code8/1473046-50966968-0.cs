    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        SignInStatus result = SignInStatus.Failure;
        var user = UserManager.FindByEmail(model.Email);
        if (user != null)
        {
            var isPasswordOk = UserManager.CheckPassword(user, model.Password);
            if (isPasswordOk)
            {
                user.Claims.Add(new IdentityUserClaim() { ClaimType = "IsPersistent", ClaimValue = model.RememberMe.ToString() });
                await SignInManager.SignInAsync(user, model.RememberMe, false);
                result = SignInStatus.Success;
            }
        }
        // This doesn't count login failures towards account lockout
        // To enable password failures to trigger account lockout, change to shouldLockout: true
        //var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
        switch (result)
        {
            case SignInStatus.Success:
                return RedirectToLocal(returnUrl);
            case SignInStatus.LockedOut:
                return View("Lockout");
            case SignInStatus.RequiresVerification:
                return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
            case SignInStatus.Failure:
            default:
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
        }
    }
