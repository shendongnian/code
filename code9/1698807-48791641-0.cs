        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl, bool registerAsDoctor)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("MyProfile", "Home");
            }
            if (ModelState.IsValid)
            {
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = (registerAsDoctor) ? (ApplicationUser)
                              new Doctor(model.Email) : new Patient(model.Email);
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    var name = info.ExternalIdentity.Name.Split(' ');
                    user.LastName = name[1];
                    user.FirstName = name[0];
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await UserManager.AddToRoleAsync(user.Id, (registerAsDoctor) ? "Doctor" : "Patient");
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        RedirectToAction("MyProfile", "Home");
                    }
                }
                AddErrors(result);
            }
            ViewBag.ReturnUrl = returnUrl;
            return RedirectToAction("Index", "Home");
        }
