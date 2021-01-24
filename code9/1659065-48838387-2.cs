    services.AddIdentityServer()
	    .AddDeveloperSigningCredential()
		.AddInMemoryApiResources(Config.GetApiResources())
		.AddInMemoryIdentityResources(Config.GetIdentityResources())
		.AddInMemoryClients(Config.GetClients()
		.AddTestUsers(Config.GetUsers()); //<--- this line here
