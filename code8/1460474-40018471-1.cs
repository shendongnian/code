    [HttpGet]
    public ActionResult Downloads()
    {
    	ViewBag.UserTypes = GetUserTypes();
    	ViewBag.Columns = GetColumns();
    
    	SearchDownloadsModelmodel = new SearchDownloadsModel();            
    	model.psColumnsSelected = new List<string>() { "user", "file" }; //preselected values
    	return View(model);
    }
    
    [HttpPost]
    public ActionResult Downloads(SearchDownloadsModel model)
    {
    	ViewBag.UserTypes = GetUserTypes();
    	ViewBag.Columns = GetColumns();     
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
