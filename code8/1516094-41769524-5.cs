    // GET: Worts/Details
    public ActionResult Details(int? id)
    {
        var wort = WortService.GetWort(id);
        return View(wort);
    }
