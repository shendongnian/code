     public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
    
                ApplicationUser signedUser = UserManager.FindByEmail(model.Email);
                var result = await SignInManager.PasswordSignInAsync(signedUser.UserName, model.Password, model.RememberMe, shouldLockout: true);
    
                switch (result)
                {
                    case SignInStatus.Success:
                        if (signedUser.UserAccessType == "Student")
                        {
                            var ObjStudent = dbContext.Students.Find(signedUser.Id);                 
                            TempData["Student"] = ObjStudent;
                            
                        }
                        else if (signedUser.UserAccessType == "Instructor")
                        {
                            var ObjInstructor = dbContext.Instructors.Find(signedUser.Id);
                            TempData["Instructor"] = ObjInstructor;
                        }
                        else if (signedUser.UserAccessType == "Admin")
                        {
                            var ObjAdmin = dbContext.Users.Find(signedUser.Id);
                            TempData["Admin"] = ObjAdmin;
                        }
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
