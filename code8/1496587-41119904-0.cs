        private static readonly Lazy<IServiceProvider> LazyServiceProvider;
        static LodashServiceProvider()
        {
            LazyServiceProvider = new Lazy<IServiceProvider>(InitializeServiceProvider);
        }
        public static IServiceProvider GetServiceProvider() => LazyServiceProvider.Value;
        private static IServiceProvider InitializeServiceProvider()
        {
            var services = new ServiceCollection();
            //Singletons
            services.AddSingleton<ILodashInstance, LodashInstance>();
            //Transients
            services.AddTransient<ILodashDate, LodashDate>();
            services.AddTransient<ILodashMath, LodashMath>();
            services.AddTransient<ILodashNumber, LodashNumber>();
            return services.BuildServiceProvider();
        }
    }
