    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
    {
        string viewName = String.Empty;
        AspNetUser aspmodel = new AspNetUser();
        
        try
        {
                var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: false);
            if (result == SignInStatus.Success)
            {
                TryUpdateModel(aspmodel, "", new string[] { "Id", "IsEnabled" });
                if (aspmodel.IsEnabled == 0)  
                {
                    AuthenticationManager.SignOut(); //toj del vidi go kako go pravi I nekoj message ke stavime. 
                    ModelState.AddModelError("", Resources.UnableToLoginText); 
                }
                else {
                //vo HOME ke odredi vo zavisnot od koj role 
                //Applicant da go nosi vo HES 
                //Student da go nosi vo SIS 
                //Officer da go nosi vo MAIN Layout pa od tamu da bira
                //Donor da go nosi vo SIS
               return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", Resources.UnableToLoginText); 
            }
        }
        catch {
            //ModelState.AddModelError("", Resources.UnableToLoginText);
        }
        return View(_ViewForLogin);
    }
