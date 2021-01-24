    [HttpGet]
    public ActionResult Register()
    {
        var model = new RegistrationModel();
        return View(model);
    }
