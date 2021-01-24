    public static class ConfigurationExtensions
    {
        public static IConfigurationProxy Proxy = new ConfigurationProxy();
        public static T GetValue<T>(this IConfigurationRoot config, string key) => Proxy.GetValue<T>(config, key);
    }
