        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            // Adjustment to params from the default settings
            services.AddIdentity<ApplicationUser, ApplicationRole>()
          .AddEntityFrameworkStores<ApplicationDbContext, int>()
          .AddDefaultTokenProviders();
            services.AddMvc();
            #region Configure all Claims Policies
            services.AddAuthorization(options =>
            {
                //options.AddPolicy("Administrators", policy => policy.RequireRole("Admin"));
                options.AddPolicy("Administrators", policy => policy.RequireClaim(ClaimTypes.Role, "Admin")); // This works the same as the above code
                options.AddPolicy("Name", policy => policy.RequireClaim(ClaimTypes.Name, "Bhail"));
            
            });
            #endregion
            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }
