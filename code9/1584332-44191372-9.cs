        public IServiceProvider ConfigureServices(IServiceCollection services) {
            services.AddDbContext<CommunicatorContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddCookieAuthentication();
            services.Configure<LdapConfig>(Configuration.GetSection("Ldap"));
            services.AddScoped<ILdapService, LdapService>();
            services.AddMvc();
            
            // Build the intermediate service provider then return it
            return services.BuildServiceProvider();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
                              ILoggerFactory loggerFactory, IServiceProvider serviceProvider) {
            
            //...Other code removed for brevity
            
            app.UseMvc();
            
            //resolve dependencies
            var dbContext = serviceProvider.GetService<CommunicatorContext>();
            var ldapService = serviceProvider.GetService<ILdapService>();
            DbInitializer.Initialize(dbContext, ldapService);
        }
