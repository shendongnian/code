    [HttpPost]
    public ActionResult Login(LoginViewModel model)
    {
         // Process login
         // after he loged in
         // Check if he is an admin, if not log out using :
         await signInManager.SignOutAsync();
         // then redirect to login page with a message
    }
