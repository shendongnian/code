    private async Task CreateRoles(RoleManager<ApplicationRole> roleManager)
    {
        var roles = new List<ApplicationRole>
        {
            // These are just the roles I made up. You can make your own!
            new ApplicationRole {Name = RoleName.SiteAdmin,
                                 Description = "Full access to all features."},
            new ApplicationRole {Name = RoleName.CompanyAdmin,
                                 Description = "Full access to features within their company."}
        };
        foreach (var role in roles)
        {
            if (await roleManager.RoleExistsAsync(role.Name)) continue;
            var result = await roleManager.CreateAsync(role);
            if (result.Succeeded) continue;
            // If we get here, something went wrong.
            throw new Exception($"Could not create '{role.Name}' role.");
        }
    }
