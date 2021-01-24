    services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
                    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
                })
                .AddGoogle("Google", options =>
                {
                    options.AccessType = "offline";
                    options.SignInScheme = IdentityConstants.ExternalScheme;
                    options.ClientId = Configuration.GetSection("Settings:GoogleClientId").Value;
                    options.ClientSecret = Configuration.GetSection("Settings:GoogleClientSecret").Value;
                });
