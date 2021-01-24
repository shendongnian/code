    public MyClass 
    {
        private readonly ISessionHelper _helper;
        public MyClass(ISessionHelper helper)
        {
            this._helper = helper;
        }
        public ActionResult InviteUser(string Id)
        {
          if (!string.IsNullOrEmpty(Id))
          {
            this._helper.SetSessionVariable("verification_uid", Id);
            return RedirectToAction("Login", "Account"); 
          }
          return View();
        }
    }
