    public class SettingsManager
    {
    
        public static string ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                var result = appSettings[key] ?? string.Empty;
                return result;
            }
            catch (ConfigurationErrorsException exc)
            {
                //Logger.WriteLog(exc.Message, LoggingLevel.Error);
            }
            return string.Empty;
        }
    
        public static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                 var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                 var settings = configFile.AppSettings.Settings;
                 if (settings.Count == 0 | settings[key] == null)
                 {
                      settings.Add(key, value);
                 }
                 else
                 {
                      settings[key].Value = value;
                 }
                 configFile.Save(ConfigurationSaveMode.Modified);             
                 ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException exc)
            {
                //Logger.WriteLog(exc.Message, LoggingLevel.Error);
            }
        }
    }
