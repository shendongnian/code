    public ActionResult Index( )
    {
        var model = new SessionHelper();
        return View(model);
    }
