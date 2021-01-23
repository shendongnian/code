    internal static class AppSettings
    {
    	public static string get_Value(string NodeName)
    	{
    		ConfigurationManager.RefreshSection("appSettings");
    		return ConfigurationManager.AppSettings[NodeName];
    	}
    	public static void set_Value(string NodeName, string value)
    	{
    		Configuration Config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
    		Config.AppSettings.Settings[NodeName].Value = value;
    		Config.AppSettings.SectionInformation.ForceSave = true;
    		Config.Save(ConfigurationSaveMode.Modified);
    		ConfigurationManager.RefreshSection("appSettings");
    	}
    }
