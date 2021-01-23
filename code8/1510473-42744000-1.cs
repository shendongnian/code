    public static IPropertySet Settings
    {
        get
        {
            return Windows.Storage.ApplicationData.Current.LocalSettings.Values;
        }
    }
