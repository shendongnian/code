    // GET: Spots
    public ActionResult Index(string filter = "")
    {
        ViewBag.initialFilter = filter;
        if (User.IsInRole("SiteAdmin"))
        {
            return View(db.Spots.ToList());
        }
        else
        {
            return View(db.Spots.Where(x => x.Approved).ToList());
        }
    }
