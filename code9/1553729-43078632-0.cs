    public static class ServicesConfiguration
    {
    	public static void AddCustomServices(this IServiceCollection services)
    	{
    		services.AddTransient<IMyService, MyService>();
    	}
    }
