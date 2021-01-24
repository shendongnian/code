    private T GetInternal<T>(string configName)
    {
     
        string value = GetConfigSetting(configName);
        if (string.IsNullOrWhiteSpace(value))
                return default(T);
        
        TypeConverter conv = TypeDescriptor.GetConverter(typeof(T));
        return (T)conv.ConvertFromString(value);
    }
