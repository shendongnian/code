	services.AddSingleton(new InMemoryUserStore()); //<-- new
	
	services.AddIdentityServer()
		.AddDeveloperSigningCredential()
		.AddInMemoryApiResources(Config.GetApiResources())
		.AddInMemoryIdentityResources(Config.GetIdentityResources())
		.AddInMemoryClients(Config.GetClients())
		.AddProfileService<UserProfileService>(); //<-- new
