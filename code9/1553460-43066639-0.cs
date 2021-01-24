    // Example of EF DbContext seeding I use in my application
    using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
    {
        using (var context = scope.ServiceProvider.GetRequiredService<MyDbContext>())
        {
            if(context.Database.EnsureCreated())
            {
                context.SeedAsync().Wait();
            }
        }
    }
