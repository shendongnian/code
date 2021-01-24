    private UserManager<ApplicationUser> userManager;
    public MyController()
    {
        userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>());
    }
    public async Task<ActionResult> Index()
    {
        var viewModels = db.Users.Select(u => new UserViewModel(){ Id = u.Id, Username = u.Username, Email = u.Email }).ToList();
        foreach (var userModel in viewModels)
        {
            userModel.IsAdmin = await userManager.IsInRoleAsync(userModel.Id, "Admin");
        }
        return View(viewModels);
    }
