            public void ConfigureServices(IServiceCollection services)
            {
                // Add MVC services to the services container.
                services.AddMvc();
    
                // Add Authentication services.
                services.AddAuthentication(sharedOptions => sharedOptions.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme);
    
    
                services.AddAuthorization(options =>
                {
                    options.AddPolicy(
                        "CanAccessGroup",
                        policyBuilder => policyBuilder.RequireClaim("groups", "8e39f882-3453-4aeb-9efa-f6ac6ad8e2e0"));
                });
            }
