       // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model, HttpPostedFileBase upload, params string[] selectedRoles)
        {
             
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };                      
                    var result = await UserManager.CreateAsync(user, model.Password);
					
                    if (result.Succeeded)
                    {
                        //Add User to the selected Roles 
                        if (selectedRoles != null)
                        {
                            var addroles = await UserManager.AddToRolesAsync(user.Id, selectedRoles);
                            if (!addroles.Succeeded)
                            {
                                ModelState.AddModelError("", result.Errors.First());
                                ViewBag.RoleId = new SelectList(await RoleManager.Roles.ToListAsync("Name", "Name"));
                                return View();
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", result.Errors.First());
                        ViewBag.RoleId = new SelectList(RoleManager.Roles, "Name", "Name");
                        return View();
                    }
                    return RedirectToAction("Index");
                    // AddErrors(result);
                }
                
            }
			
            // If we got this far, something failed, redisplay form
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            ViewBag.RoleId = new SelectList(RoleManager.Roles, "Name", "Name");
            return View(model);
        }
