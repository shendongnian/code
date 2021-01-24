    [HttpPost]
    public ActionResult Index(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            this.ModelState.AddModelError("", "Invalid Login Credential. No username sent.");
            return View();
        }
        var manager = new UserManager();
        var result = manager.ValidateUserStoredProcedure(username, password);
        switch (result.Status)
        {
            case LoginStatus.Authorized:
                return RedirectToAction("About", "Home");
    
            case LoginStatus.InvalidCredentials:
                if (result.AttemptsRemaining < 5)
                    this.ModelState.AddModelError("", "Invalid Login Credentials. Username or password incorrect. Attempts remaining:" + result.AttemptsRemaining);
                else
                    this.ModelState.AddModelError("", "Invalid Login Credentials. Username or password incorrect.");
                break;
    
            case LoginStatus.Suspended:
                this.ModelState.AddModelError("", "Account Suspeneded");
                break;
        }
        return View();
    }
