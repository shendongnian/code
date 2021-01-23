    public interface IConfigurationService
    {
        string Get(string key);
    }
    public class ConfigurationService :IConfigurationService
    {
        public string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
