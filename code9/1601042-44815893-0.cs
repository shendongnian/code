	public static void Main(string[] args) {
			var config = new ConfigurationBuilder()
				.AddCommandLine(args)
				.Build();
			var host = new WebHostBuilder()	
				.UseKestrel()
				.UseConfiguration(config)
				.ConfigureServices(s => s.AddSingleton<IConfigurationRoot>(config))
				.UseContentRoot(Directory.GetCurrentDirectory())
				.UseIISIntegration()
				.UseStartup<Startup>()
				.Build();
			host.Run();
		}`
