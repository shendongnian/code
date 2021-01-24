    services.AddAuthorization(options =>
            {
                options.AddPolicy("ReplaceHeader",
                                  policy => policy.Requirements.Add(new ReplaceHeaderPolicy()));
            });
            services.AddSingleton<IAuthorizationHandler, ReplaceHeaderHandler>();
