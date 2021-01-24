    public ActionResult Save(SomeViewModel model)
    {
        AlertifyMessages.Add(AlertifyType.Success, "Yay!", Url.Action("Index"));
        return RedirectToAction("Index");
    }
    public ActionResult Index()
    {
        return View();
    }
