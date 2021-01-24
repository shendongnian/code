	// This method gets called by the runtime. Use this method to add services to the container.
	public void ConfigureServices(IServiceCollection services)
	{
		services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
		services.AddIdentity<ApplicationUser, IdentityRole>()
			.AddEntityFrameworkStores<ApplicationDbContext>()
			.AddDefaultTokenProviders();
        //*********************************************************************
		// Add policy for record owner 
		services.AddAuthorization(options =>
		{
			options.AddPolicy("RecordOwner", policy =>
				policy.Requirements.Add(new RecordOwnerRequirement()));
		});
        //*********************************************************************
		// Add application services.
		services.AddTransient<IEmailSender, EmailSender>();
		
        //*********************************************************************
		// Register record owner handler with the DI container 
		services.AddTransient<IAuthorizationHandler, RecordOwnerHandler>();
        services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
        //*********************************************************************
		services.AddMvc();
	}
