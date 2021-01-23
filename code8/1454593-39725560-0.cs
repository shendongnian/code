    private static SuperModel _settingsObject;
    
    static Settings
    {
        string json = File.ReadAllText(SettingsConfig.ConfigFilePath);
        var jsonObj = JsonConvert.DeserializeObject<SuperModel>(json);
        _settingsObject = jsonObj;
    }
