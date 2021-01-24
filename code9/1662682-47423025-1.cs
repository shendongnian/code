        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1.access")
                {
                    UserClaims = new List<string>
                    {
                        JwtClaimTypes.Name, // or just put "name"
                        JwtClaimTypes.WebSite // or just put "website" 
                    },
                    Scopes = new List<Scope>
                    {
                        new Scope("api1.access")
                    }
                }
            };
        }
