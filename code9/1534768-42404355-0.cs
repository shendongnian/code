    public static IEnumerable<ApiResource> GetApis()
    {
        return new[]
        {
            // simple API with a single scope (in this case the scope name is the same as the api name)
            new ApiResource("api1", "Some API 1"),
    
            // expanded version if more control is needed
            new ApiResource
            {
                Name = "api2",
    
                // secret for using introspection endpoint
                ApiSecrets =
                {
                    new Secret("secret".Sha256())
                },
    
                // include the following using claims in access token (in addition to subject id)
                UserClaims = { JwtClaimTypes.Name, JwtClaimTypes.Email }
                },
    
                // this API defines two scopes
                Scopes =
                {
                    new Scope()
                    {
                        Name = "api2.full_access",
                        DisplayName = "Full access to API 2",
                    },
                    new Scope
                    {
                        Name = "api2.read_only",
                        DisplayName = "Read only access to API 2"
                    }
                }
            }
        };
    }
