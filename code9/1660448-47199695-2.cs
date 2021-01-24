     new Client
                    {
                        ClientId = "ServiceAccountAccess",
                        // no interactive user, use the clientid/secret for authentication
                        AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                        // secret for authentication
                        ClientSecrets =
                        {
                            new Secret("secret".Sha256())
                        },
                        // scopes that client has access to
                        AllowedScopes =
                        {
                            "api.full_access" ,
                             IdentityServerConstants.StandardScopes.OpenId,
                             IdentityServerConstants.StandardScopes.Profile
                        },
                        AlwaysIncludeUserClaimsInIdToken = true
                    }
