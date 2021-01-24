    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Login(UserLoginViewModel model)
    {
        if (!this.ModelState.IsValid)
        {
            return this.View();
        }
        ...
    }
