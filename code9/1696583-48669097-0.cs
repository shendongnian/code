    public ActionResult Index()
    {
        TempData["AfterRedirectVar"] = "Something";
        RedirectToAction("Redirected", "Auth", new { data = "test" });
    }
    public ActionResult Redirected(string data = "")
    {
       string tempVar = TempData["AfterRedirectVar"] as string;
       return View();
    }
