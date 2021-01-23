     public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
              var user = new ApplicationUser
                {
                    FirstName = "Abc",
                    LastName = "Pqr",
                    UserName = "Abc@yahoo.com",
                    Email= model.Email,
                    Password= model.Password,
                    PasswordHash = UserManager.PasswordHasher.HashPassword(model.Password),
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                var result = await UserManager.CreateAsync(user);
            if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);                    
                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }
          
            return View(model);
        }
