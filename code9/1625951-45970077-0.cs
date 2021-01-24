     // clients want to access resources (aka scopes)
            public static IEnumerable<Client> GetClients()
            {
                // client credentials client
                return new List<Client>
                {
                    new Client
                    {
                        ClientId="swaggerui",
                        ClientName = "Swagger UI",
                        AllowedGrantTypes=GrantTypes.Implicit,
                        AllowAccessTokensViaBrowser=true,
                        RedirectUris = { "http://localhost:49831/swagger/o2c.html" },
                        PostLogoutRedirectUris={ "http://localhost:49831/swagger/" },
                        AllowedScopes = {"api1"}
                    },
        ...
        ...
        ...
       }
    }
