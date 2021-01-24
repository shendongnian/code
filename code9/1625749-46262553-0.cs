            [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email.Trim(), model.Password.Trim(), model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    var userId = await SignInManager.GetVerifiedUserIdAsync();
                    if (userId == null)
                    {
                        return RedirectToAction("redirectSendTwoFactorCodeAsync", "Account",
                            new
                            {
                                ReturnUrl = returnUrl,
                                Email = model.Email,
                                Password = model.Password,
                                RememberMe = model.RememberMe
                            });
                    }
                    if (!await SignInManager.SendTwoFactorCodeAsync(twoPartCode))
                    {
                        ModelState.AddModelError("", "Failure sending Email verification token");
                        return View(model);
                    }
                    return View("VerifyCode", new VerifyCodeViewModel { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> redirectSendTwoFactorCodeAsync(string ReturnUrl, string Email, string Password, bool RememberMe)
        {
            if (!await SignInManager.SendTwoFactorCodeAsync(twoPartCode))
            {
                ModelState.AddModelError("", "Failure sending Email verification token");
                return View("Login", new LoginViewModel()
                {
                    Email = Email,
                    Password = Password,
                    RememberMe = RememberMe
                });
            }
            return View("VerifyCode", new VerifyCodeViewModel { ReturnUrl = ReturnUrl, RememberMe = RememberMe });
        }
