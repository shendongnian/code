    public static void UpdateConfig(string setting, string value, bool isUserSetting = false)
        {
            var assemblyPath = AppDomain.CurrentDomain.BaseDirectory;
            var assemblyName = "AssemblyName";
            //need to modify the configuration file, launch the server with those settings.
            var config =
                ConfigurationManager.OpenExeConfiguration(string.Format("{0}\\{1}.exe", assemblyPath, "AssemblyName"));
            //config.AppSettings.Settings["Setting"].Value = "false";
            var getSection = config.GetSection("applicationSettings");
            Console.WriteLine(getSection);
            var settingsGroup = isUserSetting
                ? config.SectionGroups["userSettings"]
                : config.SectionGroups["applicationSettings"];
            var settings =
                settingsGroup.Sections[string.Format("{0}.Properties.Settings", assemblyName)] as ClientSettingsSection;
            var settingsElement = settings.Settings.Get(setting);
            settings.Settings.Remove(settingsElement);
            settingsElement.Value.ValueXml.InnerText = value;
            settings.Settings.Add(settingsElement);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
