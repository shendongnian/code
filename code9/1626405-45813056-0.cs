    IServiceScopeFactory scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            
    using (IServiceScope scope = scopeFactory.CreateScope()) {
        RoleManager<IdentityRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        // Seed database code goes here
    }
