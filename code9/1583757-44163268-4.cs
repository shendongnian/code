	public Startup(IHostingEnvironment env)
	{
		var builder = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
			.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
			.AddUserSecrets<Startup>(); // <-- note here
			.AddEnvironmentVariables();
		Configuration = builder.Build();
	}
    public IConfigurationRoot Configuration { get; }
	public void ConfigureServices(IServiceCollection services)
	{
		string testSecret = Configuration["Secret"];
	}
