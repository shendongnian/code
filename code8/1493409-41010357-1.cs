     services.AddIdentityServer()
        .AddTemporarySigningCredential()
        .AddInMemoryApiResources(Config.GetApiResources())
        .AddInMemoryClients(Config.GetClients());
        .AddInMemoryIdentityResources(Config.GetIdentityResources()) // <-- adding identity resources/scopes
