    public ActionResult Index()
    {
        var tblEmployeeADPs = db.tblEmployeeADPs
            .Where(p => p.Status == "Active")
            .Select(p => p)
        return View(tblEmployeeADPs.ToList());
    }
