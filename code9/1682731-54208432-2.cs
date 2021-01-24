    // add authorization for application users
            var section = Configuration.GetSection($"AuthorizedAdUsers");
            var roles = section.Get<string[]>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdUser", policy => policy.RequireRole(roles));
            });
