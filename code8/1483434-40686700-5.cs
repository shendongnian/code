    private async Task ConfigureSiteAdmin(
        RoleManager<ApplicationRole> roleManager,
        UserManager<ApplicationUser> userManager)
    {
        if (await userManager.FindByEmailAsync(Configuration["SiteAdminEmail"]) != null)
            return;
        if (!await roleManager.RoleExistsAsync(RoleName.SiteAdmin))
            throw new Exception($"The {RoleName.SiteAdmin} role has not yet been created.");
        var user = new ApplicationUser
        {
            UserName = Configuration["SiteAdminEmail"],
            Email = Configuration["SiteAdminEmail"],
        };
        await userManager.CreateAsync(user, Configuration["SiteAdminPassword"]);
        await userManager.AddToRoleAsync(user, RoleName.SiteAdmin);
    }
