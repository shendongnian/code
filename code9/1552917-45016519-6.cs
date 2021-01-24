        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationScheme = "yourcookiename",                    
                CookieName = "YourCookieName",
                LoginPath = new PathString("/Account/Login"),
                AccessDeniedPath = new PathString("/Account/AccessDenied"),
                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            });
            
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage(); app.UseDatabaseErrorPage(); app.UseBrowserLink();
            } else { app.UseExceptionHandler("/Home/Error"); }
            app.UseStaticFiles();
            app.UseIdentity();
            // Add external authentication middleware below. To configure them please see https://go.microsoft.com/fwlink/?LinkID=532715
            app.UseMvc(routes => {
                routes.MapRoute( name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });
            
        }
