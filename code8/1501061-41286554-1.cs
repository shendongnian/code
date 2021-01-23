    public ActionResult Index()
    {
        ViewData["Message"] = "Your application description page for Switchboard.";
        ViewData["theYear"] = DateTime.Now.Year.ToString();
        getMainData();
        return View();
    }
