    public static class ServiceProvider
    {
        private static IServiceProvider serviceProvider = null;
        public static IServiceProvider GetServiceProvider()
        {
            if (serviceProvider == null) 
            {
                var services = new ServiceCollection();
                //Singletons
                services.AddSingleton<IInstance, Instance>();
                //Transients
                services.AddTransient<IDate, Date>();
                services.AddTransient<IMath, Math>();
                services.AddTransient<INumber, Number>();
                serviceProvider = services.BuildServiceProvider();
            }
            return serviceProvider;
        }
    }
