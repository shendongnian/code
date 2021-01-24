    public static class ServiceCollectionExtensions
    {
        internal static readonly IDictionary<NamedServiceDescriptor, Type> nameToTypeMap 
            = new ConcurrentDictionary<NamedServiceDescriptor, Type>();
        public static IServiceCollection AddSingleton<TService, TImplementation>(
            this IServiceCollection serviceCollection, 
            string name)
            where TService : class where TImplementation : class, TService
        {
            nameToTypeMap[new NamedServiceDescriptor(name, typeof(TService))] 
                = typeof(TImplementation);
            return serviceCollection.AddSingleton<TImplementation>();
        }
    }
    public static class ServiceProviderExtensions
    {
        public static T GetService<T>(this IServiceProvider provider, string name)
        {
            if (provider == null)
                throw new ArgumentNullException(nameof(provider));
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            ServiceCollectionExtensions.nameToTypeMap.TryGetValue(
                new NamedServiceDescriptor(name, typeof(T)), out Type implementationType);
            return (T)provider.GetService(implementationType);
        }
    }
