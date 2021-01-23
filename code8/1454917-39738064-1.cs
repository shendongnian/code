    protected override void Seed(ApplicationDBContext context)
    {
        // Initialize default identity roles
        var store = new RoleStore<IdentityRole>(context);
        var manager = new RoleManager<IdentityRole>(store);               
        // RoleTypes is a class containing constant string values for different roles
        List<IdentityRole> identityRoles = new List<IdentityRole>();
        identityRoles.Add(new IdentityRole() { Name = RoleTypes.Admin });
        identityRoles.Add(new IdentityRole() { Name = RoleTypes.Secretary });
        identityRoles.Add(new IdentityRole() { Name = RoleTypes.User });
        foreach(IdentityRole role in identityRoles)
        {
             manager.Create(role);
        }
       
        // Initialize default user
        var store = new UserStore<ApplicationUser>(context);
        var manager = new UserManager<ApplicationUser>(store);
        ApplicationUser admin = new ApplicationUser();
        admin.Email = "admin@admin.com";
        admin.UserName = "admin@admin.com";
        manager.Create(admin, "1Admin!");
        manager.AddToRole(admin.Id, RoleTypes.Admin); 
        // Add code to initialize context tables
        base.Seed(context);
    }
