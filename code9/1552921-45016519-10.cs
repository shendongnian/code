            public void ConfigureServices(IServiceCollection services)
            {
                // Add framework services.
                services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    
                services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();
    
                services.AddMvc();
    
                // some samples (this section must contain all the authorization policies used anywhere in the application)
                services.AddAuthorization(options => {
                    options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim("CompanyName", "YourCompany"));
                    options.AddPolicy("SalesOnly", policy => { policy.RequireClaim("department", "sales"); });
                    options.AddPolicy("HumanResources", policy => { policy.RequireClaim("department", "HR"); });
                    options.AddPolicy("FinanceSupervisor", policy => {
                        policy.RequireClaim("department", "finance");
                        policy.RequireClaim("jobTitle", "supervisor");
                    });
                });
    
    
                // Add application services.
                services.AddTransient<IEmailSender, AuthMessageSender>();
                services.AddTransient<ISmsSender, AuthMessageSender>();
            }
