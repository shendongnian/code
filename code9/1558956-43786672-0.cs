    public async Task CreateUsersAndRoles(IServiceScope serviceScope)
    {
        var userManager = serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
    
        await userManager.CreateAsync(new ApplicationUser { UserName = "ola@nordmann.no", Email = "ola@nordmann.no"}, "Password1.");
    }
