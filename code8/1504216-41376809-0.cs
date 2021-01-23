    private static DateTime? _lastSettingRead { get; set; }
    private static XDocument _cahedSettings { get; set; }
    private static XDocument Settings
    {
        get
        {
            var settingsPath = AppDomain.CurrentDomain.BaseDirectory + "\\Settings.xml";
            //Get last change Settings file datetime
            var lastSettingChange = System.IO.File.GetLastWriteTime(settingsPath);
            //If we read first time or file changed since last read
            if (!_lastSettingRead.HasValue || lastSettingChange > _lastSettingRead)
            {
                _lastSettingRead = lastSettingChange; //change read date
                _cahedSettings = XDocument.Load(settingsPath); //load settings to field
            }
            return _cahedSettings; //return cached settings from field
        }
    }
