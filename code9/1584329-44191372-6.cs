    1. The `ConfigureServices` method and access them there from the service collection. i.e.
        public IServiceProvider ConfigureServices(IServiceCollection services) {
            services.AddDbContext<CommunicatorContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddCookieAuthentication();
            services.Configure<LdapConfig>(Configuration.GetSection("Ldap"));
            services.AddScoped<ILdapService, LdapService>();
            services.AddMvc();
            
            // Build the intermediate service provider
            var serviceProvider = services.BuildServiceProvider();
            
            //resolve implementations
            var dbContext = serviceProvider.GetService<CommunicatorContext>();
            var ldapService = serviceProvider.GetService<ILdapService>();
            DbInitializer.Initialize(dbContext, ldapService);
            
            //return the provider
            return serviceProvider();
        }
