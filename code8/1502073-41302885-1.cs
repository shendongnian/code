    	public static class InfrastructureConfiguration
	{
		public static void Configure(IServiceCollection services)
        {
           services.AddTransient<MyAwesomeInfraClass>();
		}
	}
