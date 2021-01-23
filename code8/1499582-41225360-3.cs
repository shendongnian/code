    public ActionResult Index()
    {
       ViewModel viewModel = new ViewModel();
       viewModel.LastTenYears = GetLastTenYears(); //get the drop down list
       return View(viewModel); //we're passing our Model to the view
    }
