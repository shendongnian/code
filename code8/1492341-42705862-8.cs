    static class ServicesCollectionExtensions
    {
        public static void ConfigureWritable<T>(
            this IServiceCollection services, 
            IConfigurationRoot configuration, 
            string sectionName, 
            string file) where T : class, new()
        {
            services.Configure<T>(configuration.GetSection(sectionName));
            services.AddTransient<IWritableOptions<T>>(provider =>
            {
                var environment = provider.GetService<IHostingEnvironment>();
                var options = provider.GetService<IOptionsMonitor<T>>();
                IOptionsWriter writer = new OptionsWriter(environment, configuration, file);
                return new WritableOptions<T>(sectionName, writer, options);
            });
        }
    }
