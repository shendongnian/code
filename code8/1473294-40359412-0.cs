    public ActionResult Create()
    {
        ViewBag.AllSystems = new MultiSelectList(db.dbSystem.Select(x=>new { Name=x.systemName, Value=x.systemId }),"Value","Name");
        return View();
    }
