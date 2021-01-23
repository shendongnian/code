    private Context db = new Context();
    
    public ActionResult Create()
    {
        return View(new ReportCreateModel
        {
            AllSystems = new MultiSelectList(db.dbSystem,"systemName","systemId"),
            AllFrequencies = new MultiSelctList(db.dbFrequencies, "frequencyName", "frequencyID"),
            AllSql = new MultiSelectList(db.dbSQl.Select(s=>new {NAME=s.SQLName + " (" + s.sqltypes.SQLTypeName + ")",SQLID=s.SQLID}),"NAME","SQLID")
        });
    
    }
