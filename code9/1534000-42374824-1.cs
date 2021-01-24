    [ChildActionOnly]
    public ActionResult Favicon(string parameter)
    {
        string url = GetFaviconUrl(parameter);
        ViewBag.FaviconUrl = url;
        return PartialView();
    }
