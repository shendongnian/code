	public static void ForceNewConfigFile(this Type type, bool initialize = true)
	{
		var path = type.Assembly.Location + ".config";
		if (!File.Exists(path))
			throw new Exception("Cannot find file " + path + ".");
			
		AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", path);
		
		var typeOfConfigManager = typeof(ConfigurationManager);
		typeOfConfigManager.GetField("s_initState", BindingFlags.NonPublic | BindingFlags.Static).SetValue(null, 0);
		typeOfConfigManager.GetField("s_configSystem", BindingFlags.NonPublic | BindingFlags.Static).SetValue(null, null);
		
		var typeOfClientConfigPaths = typeOfConfigManager.Assembly.GetTypes().Where(x => x.FullName == "System.Configuration.ClientConfigPaths").Single();
		typeOfClientConfigPaths.GetField("s_current", BindingFlags.NonPublic | BindingFlags.Static).SetValue(null, null);
		
		if (initialize)
		{
			var dummy = ConfigurationManager.AppSettings;
		}
	}
