    [HttpPost]
    [Route("~/Login", Name = "LoginPOST")]
    public ActionResult Login(FormCollection UserCredentials)
    {
       //do stuff
       return RedirectToRoute("HomeView");
    }
