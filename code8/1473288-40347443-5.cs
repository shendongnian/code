    public ActionResult Create()
    {
        ViewBag.AllSystems = new MultiSelectList(db.dbSystem.Select(x=>new { Name=x.systemName, Value=s.systemId }),"Name","Value");
        ViewBag.AllFrequencies = new MultiSelectList(db.dbFrequencies.Select(x=>new { Name=x.frequencyName, Value=x.frequencyID }), "Name", "Value");
        ViewBag.AllSql = new MultiSelectList(db.dbSQl.Select(s=>new { Name=s.SQLName + " (" + s.sqltypes.SQLTypeName + ")", Value=s.SQLID}),"Name","Value");
        return View();
    }
