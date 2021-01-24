     public static class UtilsProvider
        {
            private static string _configItemOne;
    
            public static IServiceProvider SetUtilsProviderConfiguration(this IServiceProvider serviceProvider, IConfigurationRoot configuration)
            {
                // just as an example:
                _configItemOne= configuration.GetValue<string>("CONFIGITEMONE");
                return serviceProvider;
            }
            // AND ALL YOUR UTILS THAT WOULD USE THAT CONFIG COULD USE IT
        }
