      public async Task<ViewResult> Index()
        {
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = await userManager.FindAsync("UserName", "Password");
            return View(user);
        }
