        public IConfigurationRoot Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services
            services.AddMvc(
            config =>
            {
                // This enables the AuthorizeFilter on all endpoints
                var policy = new AuthorizationPolicyBuilder()
                                    .RequireAuthenticatedUser()
                                    .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
                
            }
            ).AddJsonOptions(opt =>
            {
                opt.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });
            services.AddLogging();
            services.AddAuthentication(sharedOptions =>
            {
                sharedOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                sharedOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Audience = Configuration["AzureAD:Audience"];  
                options.Authority = Configuration["AzureAD:AADInstance"] + Configuration["AzureAD:TenantId"];
            });            
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseAuthentication(); // THIS METHOD MUST COME BEFORE UseMvc...() !!
            app.UseMvcWithDefaultRoute();            
        }
