 lang-cs
    public static class ServiceCollectionExt
    {
        public static void AddSingleton<I1, I2, T>(this IServiceCollection services) 
            where T : class, I1, I2
            where I1 : class
            where I2 : class
        {
            services.AddSingleton<I1, T>();
            services.AddSingleton<I2, T>(x => (T) x.GetService<I1>());
        }
    }
