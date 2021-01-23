        public int CheckSettings()
        {
            int settings = 0;
           
            SettingsPropertyValueCollection settingsval = Properties.Settings.Default.PropertyValues;
            foreach (SettingsPropertyValue val in settingsval)
            {
                settings += val.UsingDefaultValue || String.IsNullOrWhiteSpace((string)val.SerializedValue) ? 0 : 1;
            }
            return settings;
        }
