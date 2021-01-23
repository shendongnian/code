    Settings settings = new Settings();
    public DateTime LastUpdated {get;set;}
    public Settings  GetSettings()
        {
            if (settings  == null || LastUpdated.AddMonths(1) <= DateTime.Now)
            {
                settings = // DB.GetSettings();
                LastUpdated = DateTime.Now;
            }
            return settings;
        }
