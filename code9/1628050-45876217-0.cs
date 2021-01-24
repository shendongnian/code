    public interface IConfigurationManager
    {
        T GetAppConfig<T>(string key, T defaultValue = default(T));
    }
    public class ConfigurationManager : IConfigurationManager
    {
        private readonly IConfigurationRoot config;
        public ConfigurationManager(IConfigurationRoot config)
            => this.config ?? throw new ArgumentNullException(nameof(config));
        public T GetAppConfig<T>(string key, T defaultValue = default(T))
        {
            T setting = (T)Convert.ChangeType(configuration[key], typeof(T));
            value = setting;
            if (setting == null)
                value = defaultValue;
        }
    }
