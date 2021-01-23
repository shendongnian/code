    [HttpGet]
    public ActionResult Index()
    {
        AdminViewModel viewModel = // Get Data Somehow
        return View(viewModel);
    }
    
    [HttpPost]
    public ActionResult EditCompetency(AdminViewModel viewModel)
    {
        // access competency data with viewModel.Competencies
    }
    
    [HttpPost]
    public ActionResult EditTemplate(AdminViewModel viewModel)
    {
        // access template data with viewModel.Templates
    }
