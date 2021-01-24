        public Bootstrapper(Container container, IHostingEnvironment env, ILogger logger, IServiceProvider services)
        {
            _env = env;
            _log = log;
            _services = services;
        }
 
        …
        _container.Register<IHttpContextAccessor>(() =>
            (IHttpContextAccessor) _services.GetService(typeof(IHttpContextAccessor))); 
