    [HttpPost]
    public ActionResult LoginEscolas(UserGetInfo user)
    {
        Debug.WriteLine("Error");
        if (user.username == null || user.password == null)
        {
            ViewBag.Error = "Insira os campos obrigatórios";
            return View(user);
        }
        else
        {
            if (isValid(Convert.ToInt32(user.username), user.password))
            {
                FormsAuthentication.SetAuthCookie(user.username, false);
                return RedirectToAction("Index", "Home");
            }
        }
        if(isFirstLogin(Convert.ToInt32(user.username), user.password)))
        {
			setFirstLogin(Convert.ToInt32(user.username));
			return RedirectToAction("ChangePassword");
        }
        return View(new UserGetInfo());
    }
	[HttpGet]
	public ActionResult ChangePassword(int userName)
	{
		var model = new UserGetInfo {
			username = username
		};
        return View(model);
	}
	[HttpPost]
	public ActionResult ChangePassword(int userName, string newPassword)
	{
		// Change user password
	}
	public bool isFirstLogin(int username)
	{
		// Check database to see if it is first login
	}
	public bool setFirstLogin(int username)
	{
		// Set FirstLogin to false for this user
	}
    
