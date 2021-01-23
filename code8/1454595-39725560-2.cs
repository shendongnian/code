    public static void Save()
    {
        string json = JsonConvert.SerializeObject(_settingsObject);
        File.WriteAllText(SettingsConfig.ConfigFilePath, json);
    }
