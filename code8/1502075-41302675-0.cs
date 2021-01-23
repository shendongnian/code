    System.Configuration.ExeConfigurationFileMap configFile = new System.Configuration.ExeConfigurationFileMap();
    configFile.ExeConfigFilename = "ConsoleTester.exe.config";  //name of your config file, can be from your app or external
    System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(configFile, System.Configuration.ConfigurationUserLevel.None);
    System.Configuration.KeyValueConfigurationCollection settings = config.AppSettings.Settings;
    settings["DD"].Value = "007_Access";
    config.Save();
