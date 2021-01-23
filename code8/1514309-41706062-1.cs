    public ActionResult GetAvailableLocationsFor(int accountId, int groupId)
    {
        FullConfigMV configData = SetLoader.GetDSettings(accountId, groupId);
        Utils.SiteCss = configData.CssStyles();
        TempData["config"] = configData;
        return RedirectToAction("Index","Home");
    }
    // Index ActionResult
    public ActionResult Index()
    {
        if (TempData["config"] != null)
        {
            FullConfigMV variableName = (FullConfigMV)TempData["config"];
            ...
            return View(/*whatever you want here*/);
        }
        return View();
    }
