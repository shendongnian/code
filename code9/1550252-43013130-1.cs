	public void ConfigureServices(IServiceCollection services)
	{
		// ...
		
		services.AddTransient<MyService>();
		services.AddDbContext<MyDbContext>(ServiceLifetime.Scoped);
		// ...
	}
	
