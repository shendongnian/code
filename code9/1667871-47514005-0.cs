        var cert = new X509Certificate2(Path.Combine(_currentEnvironment.ContentRootPath, "Cert\\Cert.pfx"), "123456");
                services.AddIdentityServer()
                    .AddInMemoryApiResources(Config.GetApisResources())
                    .AddSigningCredential(cert)
                    .AddInMemoryClients(Config.GetClients())
                    .AddInMemoryPersistedGrants()
                    .AddInMemoryIdentityResources(Config.GetIdentityResources())
                    .Services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();
    
    
    public class Config
        {
            public static IEnumerable<IdentityResource> GetIdentityResources()
            {
                return new List<IdentityResource>
                {
                    new IdentityResources.OpenId(),
                    new IdentityResources.Profile(),
                };
            }
            public static IEnumerable<ApiResource> GetApisResources()
            {
                return new[]
                {
                    // simple API with a single scope (in this case the scope name is the same as the api name)
                    new ApiResource("API", "api system"),
    
                };
            }
    
    
            public static IEnumerable<Client> GetClients()
            {
                return new List<Client>
                {
                    new Client
                    {
                        ClientId = "UI",
                        AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                        AccessTokenLifetime = 300,
    
                        AllowOfflineAccess=true,
                        RefreshTokenExpiration = TokenExpiration.Absolute,
                        AbsoluteRefreshTokenLifetime = 999999,
                        RefreshTokenUsage=TokenUsage.ReUse,
                        AccessTokenType=AccessTokenType.Jwt,
    
                        ClientSecrets =
                        {
                            new Secret("secretKey".Sha256())
                        },
    
                        AllowedScopes =
                        {
                            "API",
                            IdentityServerConstants.StandardScopes.OfflineAccess
                        }
                    }
                };
            }
        }
