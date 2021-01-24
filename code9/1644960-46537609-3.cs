    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
            {
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();
    
    
    
                #region Identity Server Config
                var identityServerOptions = app.ApplicationServices.GetService<IOptions<IdentityServerSettings>>().Value;
    
                // Setup Identity Server Options for this API - 
                app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
                {
                    Authority = identityServerOptions.Authority,
                    RequireHttpsMetadata = false,
                    ApiName = identityServerOptions.ApiName,
                    NameClaimType = "username",
                });
    .......
