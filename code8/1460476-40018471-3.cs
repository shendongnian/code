    [HttpGet]
    public ActionResult Downloads()
    {    
    	SearchDownloadsModelmodel = new SearchDownloadsModel();  
        model.UserTypes = GetUserTypes();
    	model.Columns = GetColumns();     
    	model.psColumnsSelected = new List<string>() { "user", "file" }; //preselected values
    	return View(model);
    }
    
    [HttpPost]
    public ActionResult Downloads(SearchDownloadsModel model)
    {
    	model.UserTypes = GetUserTypes();
    	model.Columns = GetColumns();     
    	model.psResults = GetResults(model);
    	return View(model);
    }
    public SelectList GetUserTypes()
    {
    	//...
    }
    public MultiSelectList GetColumns()
    {
    	//...
    }
    public ResultsModel GetResults()
    {
    	//...
    }
