    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult LoginUserType1(UserViewModel u)
    {
        if (ModelState.IsValid) 
        {
            // Login with UserId and PasswordType1
        }
        return View(u);
    }
    ..
    ..
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult LoginUserType2(UserViewModel u)
    {
        if (ModelState.IsValid) 
        {
            // Login with Username and PasswordType2
        }
        return View(u);
    }
