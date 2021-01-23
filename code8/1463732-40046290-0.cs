    public static class ApplicationDbContextExtensions
    {
        public static void EnsureSeedData(this ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            if (!context.Users.Any())
            {
                var result = userManager.CreateAsync(
                    new ApplicationUser { UserName = "info@example.com", Email = "info@example.com" },
                    "P@ssw0rd").Result;
            }
        }
    }
