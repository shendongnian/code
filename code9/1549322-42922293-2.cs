     [AllowAnonymous]
                public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
                {
                    // Require that the user has already logged in via username/password or external login
                    if (!await SignInManager.HasBeenVerifiedAsync())
                        return View("Error");
                    return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
                }
    
    [AllowAnonymous]
            public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
            {
                var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (loginInfo == null)
                    return RedirectToAction("Login");
    
                // Sign in the user with this external login provider if the user already has a login
                var result = await SignInManager.ExternalSignInAsync(loginInfo, false);
                switch (result)
                {
                    case SignInStatus.Success:
                        return RedirectToLocal(returnUrl);
                    case SignInStatus.LockedOut:
                        return View("Lockout");
                    case SignInStatus.RequiresVerification:
                        return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                    case SignInStatus.Failure:
                    default:
                        // If the user does not have an account, then prompt the user to create an account
                        ViewBag.ReturnUrl = returnUrl;
                        ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                        return View("ExternalLoginConfirmation",
                            new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
                }
            }
    
        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model,
            string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Manage");
    
            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                    return View("ExternalLoginFailure");
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, false, false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }
    
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }
