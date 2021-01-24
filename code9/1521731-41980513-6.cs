    public static class Startup
    {
        public static void ConfigureApp(IAppBuilder appBuilder, TinyIoCContainer container)
        {
           ...
			config.DependencyResolver = new TinyIoCResolver(container);
           ...
        }
    }
