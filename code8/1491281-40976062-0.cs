    if (PropertiesSettings.Default.UpgradeRequired)
    {
        Properties.Settings.Default.Upgrade();
        Properties.Settings.Default.UpgradeRequired = false;
        Properties.Settings.Default.Save();
        reloadSettings();
    }
    
    // Assign settings to themselves and save
    // This keeps settings the same as the defaults even when upgrading but ensures all settings appear in the config file
    private void reloadSettings()
    {
        Properties.Settings.Default.Setting1 = Properties.Settings.Default.Setting1;
        Properties.Settings.Default.Setting2 = Properties.Settings.Default.Setting2;
        //etc
        Properties.Settings.Default.Save();
    }
