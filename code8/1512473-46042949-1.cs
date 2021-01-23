     public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, CRMContext context)
            {
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();
    
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseDatabaseErrorPage();
                    app.UseBrowserLink();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                }
                
                //Fixar Cultura para en-US
                RequestLocalizationOptions localizationOptions = new RequestLocalizationOptions
                {
                    SupportedCultures = new List<CultureInfo> { new CultureInfo("en-US") },
                    SupportedUICultures = new List<CultureInfo> { new CultureInfo("en-US") },
                    DefaultRequestCulture = new RequestCulture("en-US")
                };
    
                app.UseRequestLocalization(localizationOptions);      
                app.UseStaticFiles();
                app.UseIdentity();
    
                // Add external authentication middleware below. To configure them please see https://go.microsoft.com/fwlink/?LinkID=532715
    
                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                });
    
                context.Database.EnsureCreated();
            }
