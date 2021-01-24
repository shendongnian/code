    public class AppDependencyResolver
    {
        private static AppDependencyResolver _resolver;
        public static AppDependencyResolver Current
        {
            get
            {
                if (_resolver == null)
                    throw new Exception("AppDependencyResolver not initialized. You should initialize it in Startup class");
                return _resolver;
            }
        }
        public static void Init(IServiceProvider services)
        {
            _resolver = new AppDependencyResolver(services);
        }
        private readonly IServiceProvider _serviceProvider;
        private AppDependencyResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public xxxContext CreatexxxContextinCurrentThread()
        {
            var scopeResolver = _serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            return scopeResolver.ServiceProvider.GetRequiredService<xxxContext>();
        }
    }
