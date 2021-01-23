    public static class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Ensure that the database exists and all pending migrations are applied.
            context.Database.Migrate();
            // Create roles
            string[] roles = new string[] { "UserManager", "StaffManager" };
            foreach (string role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
            // Create admin user
            if (!context.Users.Any())
            {
                await userManager.CreateAsync(new ApplicationUser() { UserName = "info@example.com", Email = "info@example.com" }, "p@ssw0rd");
            }
            // Ensure admin privileges
            ApplicationUser admin = await userManager.FindByEmailAsync("info@example.com");
            foreach (string role in roles)
            {
                await userManager.AddToRoleAsync(admin, role);
            }
        }
    }
