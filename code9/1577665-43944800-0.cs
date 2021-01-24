    public ActionResult Index()
    {
    	ViewBag.Message = TempData["Message"];
    	return View();
    }
    public ActionResult Logoff()
    {
    	DoLogOff();
    	TempData["Message"] = "Success";
    	return RedirectToAction("Index", "Home");
    }
