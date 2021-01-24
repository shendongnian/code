	public void ConfigureServices(IServiceCollection services)
	{
		services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
		{
			builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
		}));
		services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
	}
