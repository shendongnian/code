        internal static class Policies
        {
            public const string RequireAdministrator = "RequireAdministrator";
            public const string RequireOp1 = "RequireOp1";
            public const string RequireOp2 = "RequireOp2";
    
            public const string AlwaysDeny = "AlwaysDeny";
    
            public static void ConfigurePolicies(IServiceCollection services)
            {
                services.AddAuthorization(options => options.AddPolicy(RequireAdministrator, policy => policy.RequireClaim(PolicyClaims.AdministratorClaim)));
                services.AddAuthorization(options => options.AddPolicy(RequireOp1, policy => policy.RequireClaim(PolicyClaims.Operation1Claim)));
                services.AddAuthorization(options => options.AddPolicy(RequireOp2, policy => policy.RequireClaim(PolicyClaims.Operation2Claim)));
                services.AddAuthorization(options => options.AddPolicy(AlwaysDeny, policy => policy.RequireUserName("THIS$USER\n\r\t\0cannot be created")));
            }
        }
