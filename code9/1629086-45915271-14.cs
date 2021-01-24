    [HttpPost]
    [ExcludeAntiForgeryCheck]
    public ActionResult Index(ViewModel model)
    {
        // other stuff
        return View(model);
    }
