    using (var serviceScope =
        app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
    {
        var context = serviceScope.ServiceProvider.GetService<SGDTPContext>();
        // Seed the database.
    }
