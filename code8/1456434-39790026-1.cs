    public ActionResult Index()
    {
        var userDetails = db.UserDetails.Include(u => u.Roles).ToList();
        var allRoles = db.Roles.ToList();
        var viewModel = new RoleSelectionViewModel();
        viewModel.Users = userDetails;
        viewModel.Roles = allRoles;
        return View(viewModel);
    }
    
