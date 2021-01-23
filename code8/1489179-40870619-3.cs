    public class AppNancyBootstrapper : DefaultNancyBootstrapper
    {
        public AppNancyBootstrapper(IHostingEnvironment environment)
        {
            RootPathProvider = new AppRootPathProvider(environment);
        }
        protected override void ConfigureConventions(NancyConventions conventions)
        {
            base.ConfigureConventions(conventions);
    
            conventions.StaticContentsConventions.AddDirectory("css");
            conventions.StaticContentsConventions.AddDirectory("js");
            conventions.StaticContentsConventions.AddDirectory("fonts");
        }
    
        protected override IRootPathProvider RootPathProvider { get; }
    }
