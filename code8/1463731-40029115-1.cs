    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        // Code omitted for brevity
        // Create seed data
        DbInitializer.Initialize(context, userManager, roleManager).Wait();
    }
