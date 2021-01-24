    [HttpPost]
    public ActionResult Edit(ConfigurationViewModel cvm)
    {
        ConfigurationManager.AppSettings["archiveDirectoryPath"] = cvm.archiveDirectory;
        ConfigurationManager.AppSettings["SituatorIP"] = cvm.situatorIP;
        ConfigurationManager.AppSettings["SituatorPort"]= cvm.situatorPort;
        //...
        return View(cvm);
    }
