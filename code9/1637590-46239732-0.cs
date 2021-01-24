    public class RepositoryData : DbContext {
    public RepositoryData(string appSettingsOrConnectionName = null) :base(GetConnectionString(appSettingsOrConnectionName ?? "connection"))
    {
    }
    private static string GetConnectionString(string appSettingsOrConnectionName = null)
    {
            if (!string.IsNullOrEmpty(appSettingsOrConnectionName) && appSettingsOrConnectionName.Contains(";"))
                return appSettingsOrConnectionName;
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[appSettingsOrConnectionName]))
                return ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings[appSettingsOrConnectionName]].ConnectionString;
            else if (!string.IsNullOrEmpty(ConfigurationManager.ConnectionStrings[appSettingsOrConnectionName].ConnectionString))
                return ConfigurationManager.ConnectionStrings[appSettingsOrConnectionName].ConnectionString;
            else if (!string.IsNullOrEmpty(ConfigurationManager.ConnectionStrings["test"].ConnectionString))
            {
                appSettingsOrConnectionName = "test";
                return ConfigurationManager.ConnectionStrings[appSettingsOrConnectionName].ConnectionString;
            }
            else return _defaultConnString;
    }
    }
