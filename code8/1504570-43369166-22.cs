    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
            {
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();
    
                //IdentityServer4.AccessTokenValidation
                app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
                {
                    Authority = "http://localhost:5000",
                    RequireHttpsMetadata = false,
                    ApiName = "ApplicationApi"
                });
    
                app.UseMvc();
            }
