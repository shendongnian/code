	public Startup(IConfiguration configuration)
	{
		Configuration = configuration;
		//add this: simply creates db if it doesn't exist, no migrations
		using (var context = new IdentityContext())
		{
			context.Database.EnsureCreated();
		}
	}
	
	public void ConfigureServices(IServiceCollection services)
	{
		//add this: register your db context
		services.AddDbContext<IdentityContext>();
		//and this: add identity and create the db
		services.AddIdentity<ApplicationUser, IdentityRole>()
			.AddEntityFrameworkStores<IdentityContext>();
		services.AddMvc();
	}
	public void Configure(IApplicationBuilder app, IHostingEnvironment env)
	{
		//add this
		app.UseAuthentication();
		app.UseMvc();
	}
