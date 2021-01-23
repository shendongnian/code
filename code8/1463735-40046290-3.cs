    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseDatabaseErrorPage();
        app.UseBrowserLink();
        using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            // First apply pendding migrations if exist
            serviceScope.ServiceProvider.GetService<ApplicationDbContext>().Database.Migrate();
            
            // Then call seeder method
            var userManager = serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
            serviceScope.ServiceProvider.GetService<ApplicationDbContext>().EnsureSeedData(userManager);
        }
    }
