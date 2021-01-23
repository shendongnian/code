    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
            {
    
                JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
    
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();
    
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    //app.UseBrowserLink();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                }
    
                app.UseStaticFiles();
    
                // For the wwwroot folder
                //app.UseStaticFiles(new StaticFileOptions()
                //{
                //    FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(
                //        System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"wwwroot", "images")),
                //    RequestPath = new Microsoft.AspNetCore.Http.PathString("/MyImages")
                //});
    
                //app.UseDirectoryBrowser(new DirectoryBrowserOptions()
                //{
                //    FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(
                //        System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"wwwroot", "images")),
                //    RequestPath = new Microsoft.AspNetCore.Http.PathString("/MyImages")
                //});
    
                //Setup OpenId and Identity server
                app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationScheme = "Cookies",
                    AutomaticAuthenticate = true
                });
    
                app.UseOpenIdConnectAuthentication(new OpenIdConnectOptions
                {
                    Authority = "http://localhost:5000",
                    ClientId = "U2EQlBHfcbuxUo",
                    ClientSecret = "TbXuRy7SSF5wzH",
                    AuthenticationScheme = "oidc",
                    SignInScheme = "Cookies",
                    SaveTokens = true,
                    RequireHttpsMetadata = false,
                    GetClaimsFromUserInfoEndpoint = true,
                    ResponseType = "code id_token",
                    Scope = { "ApplicationApi", "DefinitionApi", "FFAPI", "openid", "profile", "offline_access" },
                    TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        NameClaimType = "name",
                        RoleClaimType = "role"
                    }
                });
                        
                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                });
            }
