    public ActionResult Index()
    {
      TempData["data"] = "test";
      RedirectToAction("Redirected", "Auth"});
    }
    public ActionResult Redirected()
    {
      var data = TempData["data"].ToString();
      return View();
    }
