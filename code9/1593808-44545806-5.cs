        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            //>Declaration
            var lIdentityResources = new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
            //>Processing
            foreach (var lAPIResource in GetApiResources())
            {
                lIdentityResources.Add(new IdentityResource(lAPIResource.Name,
                                                            lAPIResource.UserClaims));
            }
            //>Return
            return lIdentityResources;
        }
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "api1",
                    DisplayName = "api1 API",
                    UserClaims =
                    {
                        JwtClaimTypes.Id,
                        JwtClaimTypes.Subject,
                        JwtClaimTypes.Email
                    }
                }
            };
        }
