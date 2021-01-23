    public ActionResult GetAvailableLocationsFor(int accountId, int groupId)
    {
        FullConfigMV configData = SetLoader.GetDSettings(accountId, groupId);
        Utils.SiteCss = configData.CssStyles();
        return RedirectToAction("Index","Home", new { data = configData});
    }
