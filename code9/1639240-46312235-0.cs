    [OutputCache(Duration = 3600)]
    public ActionResult TestCache()
    {
        return Content(DateTime.Now.ToString());
    }
