	public class TestStartup
	{
		public void Configuration(IAppBuilder app)
		{
		    var startup = new Startup();
            app.Use<ProviderStateMiddleware>(); 
		    startup.Configuration(app);
        }
	}
