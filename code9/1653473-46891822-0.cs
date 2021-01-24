    protected override void Seed(ApplicationDbContext context)
    {
    
        if (!context.Roles.Any(r => r.Name == "Administrator"))
        {
            var store = new CustomRoleStore(context);
            var manager = new RoleManager<CustomRole, int>(store);
            var role = new CustomRole { Name = "Administrator" };
            manager.Create(role);
        }
    
        SeedNewUser(context, "email@email.com", "****", "Administrator");
    
    }
    
    private async void SeedNewUser(ApplicationDbContext context, string email, string dummyPassword, string role)
    {
        if (!context.Users.Any(u => u.UserName == email))
        {
            var store = new CustomUserStore(context);
            var manager = new ApplicationUserManager(store);
            var user = new ApplicationUser { UserName = email, Email = email, LockoutEnabled = false, EmailConfirmed = true, SecurityStamp = Guid.NewGuid().ToString() };
            
            manager.Create(user, dummyPassword);
            manager.AddToRole(user.Id, role);
        }
    }
