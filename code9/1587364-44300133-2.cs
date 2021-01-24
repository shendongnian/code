    // Login Success Authenticate
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
                    var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
                    switch (result)
                    {
                        case SignInStatus.Success:
        					{
     // check this section
        					var isGmail = Regex.IsMatch(model.Email, @"^*@g(oogle)?mail\.com$");
        
        						if (isGmail)
        						{
        							return View("GmailViewCshtml", model);
        						}
        						else
        						{
        							return RedirectToLocal(returnUrl);
        						}**
        					}
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
