    try
        {
            _webConfig.AppSettings.Settings["SettingName"].Value = textMessage;
        } catch {
            _webConfig.AppSettings.Settings.Add("SettingName", textMessage);
        }
        _webConfig.Save(ConfigurationSaveMode.Modified);
