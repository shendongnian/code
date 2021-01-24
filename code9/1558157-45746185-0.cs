        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl = "jobs")
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
           
                var user = await UserManager.FindByNameAsync(model.UserName);
                await SignInManager.SignInAsync(user, false, false);               
                return Redirect(virtualDirectory + returnUrl);
            }
            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }
