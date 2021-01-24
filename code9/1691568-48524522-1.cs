	public static IWebHost BuildWebHost(string[] args) =>
		WebHost.CreateDefaultBuilder(args)
			.UseKestrel()
			.UseIISIntegration()
			.UseStartup<Startup>()
			.Build();
