    class SettingsService
    {
        public static string GetSetting(string key)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            return config.AppSettings.Settings[key].Value.ToString();
        }
        public static void UpdateConfig(string key, string value )
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configFile.AppSettings.Settings[key].Value = value;
            configFile.Save(ConfigurationSaveMode.Modified); 
        }
    }
