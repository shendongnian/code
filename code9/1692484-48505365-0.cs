    public ActionResult Logout()
    {
        if (UserState.IsLoggedIn)
        {
            // Log the user out
        }
        return RedirectToAction("Login");
    }
    [HttpGet]
    public ActionResult Login()
    {
        if (UserState.IsLoggedIn)
        {
            return RedirectToAction("Index");
        }
        return View(new LoginViewModel(UserState));
    }
    [HttpPost]
    public ActionResult Login(LoginModel model)
    {
        if (UserState.IsLoggedIn)
        {
            return RedirectToAction("Index");
        }
        // Do the login and redirect accordingly
        if (loginWasSuccess)
        {
            return RedirectToAction("Action", "Controller");
        }
        // Otherwise, add errors to model state and reload login page with errors.
       ModelState.AddModelError("InvalidLogon", "Some error message");
       
       return View(new LoginViewModel(UserState));
    }
