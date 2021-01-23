    public void ConfigureServices(IServiceCollection services)
            {
                // Add framework services.
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    
                services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();
    
                services.AddMvc();
    
                services.AddTransient<IEmailSender, AuthMessageSender>();
                services.AddTransient<ISmsSender, AuthMessageSender>();
    
                //Add IdentityServer services
                //var certificate = new System.Security.Cryptography.X509Certificates.X509Certificate2(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "LocalhostCert.pfx"), "123456");
                services.AddIdentityServer()
                        .AddTemporarySigningCredential()
                        .AddInMemoryIdentityResources(Configs.IdentityServerConfig.GetIdentityResources())
                        .AddInMemoryApiResources(Configs.IdentityServerConfig.GetApiResources())
                        .AddInMemoryClients(Configs.IdentityServerConfig.GetClients())
                        .AddAspNetIdentity<ApplicationUser>()
                        .AddProfileService<Configs.IdentityProfileService>();
            }
    
            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
            {
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();
               
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseDatabaseErrorPage();
                    //app.UseBrowserLink();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                }
    
                app.UseStaticFiles();
    
                app.UseIdentity();
    
                // Adds IdentityServer
                app.UseIdentityServer();
    
                // Add external authentication middleware below. To configure them please see https://go.microsoft.com/fwlink/?LinkID=532715
    
                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Account}/{action=Login}/{id?}");
                });
    
            }
