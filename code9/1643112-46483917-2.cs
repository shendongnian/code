    public class AppRootPathProvider : IRootPathProvider
    {
        private readonly IHostingEnvironment _environment;
    
        public AppRootPathProvider(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        public string GetRootPath()
        {
            return _environment.WebRootPath;
        }
    }
    
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        readonly IApplicationBuilder _app;
    
        protected override IRootPathProvider RootPathProvider { get; }
    
        public Bootstrapper(IApplicationBuilder app, IHostingEnvironment environment)
        {
            RootPathProvider = new AppRootPathProvider(environment);
            _app = app;
        }
    
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
    
            container.Register<IOptions<Endpoints>>(_app.ApplicationServices.GetService<IOptions<Endpoints>>());
    
            container.Register<IReservationService>(_app.ApplicationServices.GetService<IReservationService>());
        }
    }
