    public interface IConfigurationWrapper
    {
        string GetAppSetting(string key);
    }
    public class ConfigurationWrapper : IConfigurationWrapper
    {
         public string GetAppSetting(string key)
         {
             return ConfigurationManager.AppSettings[key]
         }
    }
