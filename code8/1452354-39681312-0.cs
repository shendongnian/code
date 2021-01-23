    public static class Startup
    {
        public static void ConfigureApp(IAppBuilder app)
		{
			String connectionString = "Endpoint=sb://[name].servicebus.windows.net/;SharedSecretIssuer=owner;SharedSecretValue=[value]";
			GlobalHost.DependencyResolver.UseServiceBus(connectionString, "InSys");
			app.MapSignalR();
			Notifications.Hub = GlobalHost.ConnectionManager.GetHubContext<InSysMainHub>();
		}
    }
