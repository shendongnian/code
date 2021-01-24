    public static class Startup
    {
        public static void ConfigureApp(IAppBuilder appBuilder, TinyIoCContainer container)
        {
           ...
			var container = TinyIoCContainer.Current;
			config.DependencyResolver = new TinyIoCResolver(container);
           ...
        }
    }
