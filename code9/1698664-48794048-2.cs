    public void ConfigureServices(IServiceCollection services)
            {
                services.AddMvc();
    
                var cert = new X509Certificate2(Path.Combine(Directory.GetCurrentDirectory(), "idsrvtest.pfx"), "idsrv3test");
    
                services.AddIdentityServer()
                    .AddSigningCredential(cert)
                    .AddInMemoryIdentityResources(Config.GetIdentityResources())
                    .AddInMemoryApiResources(Config.GetApiResources())
                    .AddInMemoryClients(Config.GetClients())
                    .AddTestUsers(TestUsers.Users)
                    **.AddWsFederation();**
    ...
    }
