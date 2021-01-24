    var scopeFactory = ApplicationServices.GetService<IServiceScopeFactory>();
    using (var scope = scopeFactory.CreateScope())
    {
	    var dbContext = scope.ServiceProvider.GetService<CommunicatorDbContext>();
    	DbInitializer.Initializer(dbContext, ldapService);
    }
