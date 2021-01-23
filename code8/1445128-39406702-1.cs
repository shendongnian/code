    public string ValidateUser(string userName, string password)
    {
        var result = SignInManager.PasswordSignIn(userName, password, false, false);
        if(result==SignInStatus.Success)
            return userName;
    
        ModelState.AddModelError("", "Invalid login attempt.");
            //return View(model);
            return View();
    }
