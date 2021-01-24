     services.AddIdentityServer() // Configures OAuth/IdentityServer framework
                .AddInMemoryIdentityResources(IdentityServerConfig.GetIdentityResources())
                .AddInMemoryClients(IdentityServerConfig.GetClients(serviceSettings))
                .AddAspNetIdentity<ExtranetUser>()
                .AddTemporarySigningCredential();
