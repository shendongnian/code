    public static class IServiceCollectionExtensions
    {
        public static void RegisterOptions(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // Create all options from the given configuration.
            var options = OptionsHelper.CreateOptions(configuration);
            foreach (var option in options)
            {
                // We get back Options<MyOptionsType> : IOptions<MyOptionsType>
                var interfaces = option.GetType().GetInterfaces();
                foreach (var type in interfaces)
                {
                    // Register options IServiceCollection
                    services.AddSingleton(type, option);
                }
            }
        }
    }
