        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginInputModel model)
        {
            if (ModelState.IsValid)
            {
                // use our custom UserStore here
     -------->  if (_users.ValidateCredentials(model.Username, model.Password))
                {
                    AuthenticationProperties props = null;
                    // only set explicit expiration here if persistent. 
                    // otherwise we reply upon expiration configured in cookie middleware.
                    if (AccountOptions.AllowRememberLogin && model.RememberLogin)
                    {
                        props = new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTimeOffset.UtcNow.Add(AccountOptions.RememberMeLoginDuration)
                        };
                    };
    
                    // issue authentication cookie with subject ID and username
                    var user = _users.FindByUsername(model.Username);
                    await _events.RaiseAsync(new UserLoginSuccessEvent(user.Username, user.SubjectId, user.Username));
                    await HttpContext.Authentication.SignInAsync(user.SubjectId, user.Username, props);
    
                    // make sure the returnUrl is still valid, and if yes - redirect back to authorize endpoint or a local page
                    if (_interaction.IsValidReturnUrl(model.ReturnUrl) || Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
    
                    return Redirect("~/");
                }
    
                await _events.RaiseAsync(new UserLoginFailureEvent(model.Username, "invalid credentials"));
    
                ModelState.AddModelError("", AccountOptions.InvalidCredentialsErrorMessage);
            }
    
            // something went wrong, show form with error
            var vm = await _account.BuildLoginViewModelAsync(model);
            return View(vm);
        }
