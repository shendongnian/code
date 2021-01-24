    public async Task InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                // Create DB
                serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();
                // Add roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<long>>>();
                if (!roleManager.Roles.Any())
                {
                    foreach (var role in Config.GetTestRolls())
                    {
                        await roleManager.CreateAsync(role);
                    }
                }
                // Add users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                if (userManager.Users.Any()) return;
                foreach (var user in Config.GetTestUsers())
                {
                    await userManager.CreateAsync(user, "Password123!");
                }
                
                // find first user add to first role (hack) 
                var adminUser = await userManager.FindByEmailAsync(Config.GetTestUsers().FirstOrDefault()?.Email);
                if (adminUser != null)
                {
                    await userManager.AddToRoleAsync(adminUser, Config.GetTestRolls().FirstOrDefault()?.Name);
                }
            }
