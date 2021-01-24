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
                    HttpCookie cookie = new HttpCookie("Language");
                    cookie.Value = "ru";
                    var user = UserManager.FindByEmail(model.Email);
                   
                        var claim = user.Claims.FirstOrDefault(c => c.ClaimType == "Language");
                        
                        if (claim == null)
                        {
                            cookie.Value = Thread.CurrentThread.CurrentCulture.Name.ToString(); // interface language used befor logining in
                        }
                        else
                            cookie.Value = claim.ClaimValue; // Language from the UserClaim 
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cookie.Value);
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(cookie.Value);
                    Response.Cookies.Add(cookie);
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
 
