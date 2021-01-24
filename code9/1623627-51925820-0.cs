           services.AddMvc(options =>
            {
                var defaultPolicy = new AuthorizationPolicyBuilder(new[] { CookieAuthenticationDefaults.AuthenticationScheme, JwtBearerDefaults.AuthenticationScheme, OpenIdConnectDefaults.AuthenticationScheme })
                          .RequireAuthenticatedUser()
                          .Build();
                options.Filters.Add(new AuthorizeFilter(defaultPolicy));
            })
