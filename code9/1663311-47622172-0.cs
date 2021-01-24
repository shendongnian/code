    services.AddAuthorization(options =>
            {
                options.AddPolicy(DefaultAuthorizedPolicy, policy =>
                {
                    policy.Requirements.Add(new TokenAuthRequirement());
                    policy.AuthenticationSchemes = new List<string>()
                                    {
                                        CookieAuthenticationDefaults.AuthenticationScheme
                                    }
                });
            });
