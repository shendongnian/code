    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public ActionResult Login(LoginViewModel model, string returnUrl) {
        if (!ModelState.IsValid) {
            return View(model);
        }
              
        // we use simple forms authentication with a list of user in the web.config file 
        if (FormsAuthentication.Authenticate(model.UserName, model.Password)) {
            FormsAuthentication.RedirectFromLoginPage(model.UserName, false);
        }
        ModelState.AddModelError("", Global.Login_Unsuccessful);
        return View(model);
    }
