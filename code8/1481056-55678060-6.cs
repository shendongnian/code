    public static class ServiceLocator
    {
        private static IServiceProviderProxy diProxy;
    
        public static IServiceProviderProxy ServiceProvider => diProxy ?? throw new Exception("You should Initialize the ServiceProvider before using it.");
    
        public static void Initialize(IServiceProviderProxy proxy)
        {
            diProxy = proxy;
        }
    }
