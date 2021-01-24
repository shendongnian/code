    public static class ServiceCollectionExtensions
    {
        public static void AddScopedInterfaceAndClass<TInterface, TClass>(this IServiceCollection serviceCollection)
            where TInterface : class
            where TClass : class, TInterface
        {
            serviceCollection.AddScoped<TClass>();
            serviceCollection.AddScoped<TInterface, TClass>(
                sp => sp.GetRequiredService<TClass>());
        }
    }
