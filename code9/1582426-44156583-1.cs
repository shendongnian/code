    public virtual ActionResult Plan(long projectID, int year)
    {
        var viewModel = new PlaningViewModel
            {
                ProjectID = projectID,
                Year = year
            };
        return View("Index", LoadViewModel(viewModel));
    }
    public PlaningViewModel LoadViewModel(PlaningViewModel viewModel)
    {
        // Load data from database with viewModel.ProjectID
        // and viewModel.Year as parameters
        [...]
        var vm = new PlaningViewModel
            {
                // Set ViewModel for loaded data
                [...]
            };
        return vm;
    }
