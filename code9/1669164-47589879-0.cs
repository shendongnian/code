    services.AddAuthorization(options =>
            {
                var roles = new List<string>{ Role.Administrator, Role.Manager};
                var requirement =
                    new List<IAuthorizationRequirement> {new AdminManagerAuthorizationOverrideOthers(roles) };
                var sharedAuthentication =
                    new AuthorizationPolicy(requirement,
                        new List<string>());
                options.AddPolicy(name: "AdminManager", policy: sharedAuthentication);
                options.AddPolicy(name: "Administrator", configurePolicy: policy => policy.RequireAssertion(e =>
                {
                    if (e.Resource is AuthorizationFilterContext afc)
                    {
                        var noPolicy = afc.Filters.OfType<AuthorizeFilter>().Any(p =>
                            p.Policy.Requirements.Count == 1 &&
                            p.Policy.Requirements.Single() is AdminManagerAuthorizationOverrideOthers);
                        if (noPolicy)
                            return true;
                    }
                    return e.User.IsInRole(Role.Administrator);
                }));
            });
