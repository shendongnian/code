    Dictionary<string,string> settings = new Dictionary<string,string>;
    foreach (System.Configuration.SettingsProperty sp in Properties.Settings.Default.Properties)
    {
        string Setting = sp.Name;
        string Value = Properties.Settings.Default[sp.Name].ToString();
        settings.Add(Setting,Value);
    }
