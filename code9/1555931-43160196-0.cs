    public ActionResult Index()
    {
        ViewBag.MyImage = Convert.ToBase64String(MyImage);
        return View();
    }
