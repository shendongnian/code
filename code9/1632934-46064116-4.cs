    using (var serviceScope = app.ApplicationServices.CreateScope())
    {
        var context = serviceScope.ServiceProvider.GetService<SGDTPContext>();
        
        // Seed the database.
    }
