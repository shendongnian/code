        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1.access")
                {
                    UserClaims = new List<string>
                    {
                        JwtClaimTypes.Name,
                        JwtClaimTypes.WebSite
                    },
                    Scopes = new List<Scope>
                    {
                        new Scope("api1.access")
                    }
                }
            };
        }
