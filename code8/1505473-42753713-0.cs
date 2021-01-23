        // POST: /Account/Login
        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<ReturnValue<ApplicationUser>> Login([FromBody] loginModel login)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindByEmailAsync(login.email);
                if (user == null)
                {
                    return new ReturnValue<ApplicationUser>(false, "Login failed, check username and password.", null);
                }
                // else if (user.EmailConfirmed == false)
                // {
                //     return new ReturnValue<ApplicationUser>(true, "Confirm email address.", null, user);
                // }
                else
                {
                    // This doesn't count login failures towards account lockout
                    // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                    var result = await _signInManager.PasswordSignInAsync(user, login.password, (bool)login.rememberMe, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        return new ReturnValue<ApplicationUser>(true, user);
                    }
                    //if (result.RequiresTwoFactor)
                    //{
                    //    return RedirectToAction(nameof(SendCode), new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                    //}
                    if (result.IsLockedOut)
                    {
                        return new ReturnValue<ApplicationUser>(false, "The account is locked out.", null);
                    }
                }
            }
            else
            {
                string message = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                return new ReturnValue<ApplicationUser>(false, "Invalid login attempt: " + message, null);
            }
            // If we got this far, something failed in the model.
            return new ReturnValue<ApplicationUser>(false, "Login failed.", null);
        }
