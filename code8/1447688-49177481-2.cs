        public static void AddSettings<T>(this IServiceCollection serviceCollection, IConfiguration configuration) where T : class, new()
        {
            var settings = new T();
            configuration.Bind(typeof(T).Name, settings);
            serviceCollection.AddSingleton(settings);
        }
