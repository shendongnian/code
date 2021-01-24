    class BoolToToggleSwitchOnOffContentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool boolValue)
            {
                var resourceLoader = ResourceLoader.GetForCurrentView();
                var resourceString = "ToggleSwitch" + (boolValue ? "On" : "Off");
                return resourceLoader.GetString(resourceString);
            }
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            // I'm afraid I can't do that, Dave!
            throw new NotImplementedException();
        }
    }
