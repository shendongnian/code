    public class ServiceJobActivator : IJobActivator
    {
    
        IServiceProvider _serviceProvider;
    
        public ServiceJobActivator(IServiceCollection serviceCollection) : base()
        {
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
    
        public T CreateInstance<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }
    }
