	public void ConfigureServices(IServiceCollection services)
	{	
		var authBuilder = services.AddAuthentication(options =>
		{
			options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
			options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
		});
		// cookie authentification
		authBuilder.AddCookie(options =>
		{
			 // sets the time after which a cookie expires, and thus the user needs to be re-auth
			options.ExpireTimeSpan = TimeSpan.FromDays(14);
		});
		// OpenID Connect
		authBuilder.AddOpenIdConnect(options =>
		{
			// not relevant
		});
		
		services.AddMvc();
	}
	public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
	{
		app.UseAuthentication();
		app.UseMvc();
	}
