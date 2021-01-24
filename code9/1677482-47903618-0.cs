    public ActionResult Index(User user)
    {
        var viewModel = new ViewModel();
        viewModel.User = user;
        viewModel.ProjectsList = Pdb.DbSet.ToList();
        viewModel.WorkerList = Wdb.DbSet.ToList();
        TempData["MyViewModel"] = viewModel;
        return View(viewModel);
    }
