    public void ConfigureServices(IServiceCollection services)
        {
            // Add CORS
            services.AddCors();
            // Add authentication before adding MVC
            // Add JWT and Azure AD (that uses OpenIdConnect) and cookies.
            // Use a smart policy scheme to choose the correct authentication scheme at runtime
            services
                .AddAuthentication(sharedOptions =>
                {
                    sharedOptions.DefaultScheme = "smart";
                    sharedOptions.DefaultChallengeScheme = "smart";
                })
                .AddPolicyScheme("smart", "Authorization Bearer or OIDC", options =>
                {
                    options.ForwardDefaultSelector = context =>
                    {
                        var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
                        if (authHeader?.StartsWith("Bearer ") == true)
                        {
                            return JwtBearerDefaults.AuthenticationScheme;
                        }
                        return OpenIdConnectDefaults.AuthenticationScheme;
                    };
                })
                .AddJwtBearer(o =>
                {
                    o.Authority = Configuration["JWT:Authentication:Authority"];
                    o.Audience = Configuration["JWT:Authentication:ClientId"];
                    o.SaveToken = true;
                })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddAzureAd(options => Configuration.Bind("AzureAd", options));
            services
                .AddMvc(config =>
                {
                    var policy = new AuthorizationPolicyBuilder()
                                     .RequireAuthenticatedUser()
                                     .Build();
                    // Authentication is required by default
                    config.Filters.Add(new AuthorizeFilter(policy));
                    config.RespectBrowserAcceptHeader = true;
                });
                
                ...
                
                }
