    public ActionResult Register()
    {
        ViewBag.LoggedIn = false;
        var model =  new User();
        return View(model);
    }
