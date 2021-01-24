        var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
        using (var serviceScope = serviceScopeFactory.CreateScope())
        {
            var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            dbContext.Database.EnsureCreated();
        }
