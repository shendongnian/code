    public ActionResult Create()
    {
        ViewBag.AllSystems = db.dbSystem.Select(x=>new { Name=x.systemName, Value=s.systemId });
        ViewBag.AllFrequencies = db.dbFrequencies.Select(x=>new { Name=x.frequencyName, Value=x.frequencyID });
        ViewBag.AllSql = db.dbSQl.Select(s=>new { Name=s.SQLName + " (" + s.sqltypes.SQLTypeName + ")", Value=s.SQLID});
        return View();
    }
