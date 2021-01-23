    public ActionResult Index()
    {
        Process.Start(@"pathToYurConsoleAppEXE");
        return View();
    }
