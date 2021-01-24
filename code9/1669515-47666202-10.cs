        public Bootstrapper(IHostingEnvironment env, ILogger log, IServiceProvider services)
        {
            _env = env;
            _log = log;
            _services = services;
        }
 
        …
        _container.Register<IHttpContextAccessor>(() =>
            (IHttpContextAccessor) _services.GetService(typeof(IHttpContextAccessor))); 
