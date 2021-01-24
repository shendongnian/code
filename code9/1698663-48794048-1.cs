    public static IEnumerable<Client> GetClients()
            {
                return new[]
                {
                    new Client
                    {
                        ClientId = "urn:owinrp",
                        ProtocolType = ProtocolTypes.WsFederation,
    
                        RedirectUris = { "http://localhost:10313/" },
                        FrontChannelLogoutUri = "http://localhost:10313/home/signoutcleanup",
                        IdentityTokenLifetime = 36000,
    
                        AllowedScopes = { "openid", "profile" }
                    }
                }
             }
    
