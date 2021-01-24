    public static T SetEmptyPropertiesNull<T>(T request)
    {
        foreach (PropertyInfo property in typeof(T).GetProperties())
        {
            object value = property.GetValue(request, null);
    
            if (typeof(value).IsClass)
                SetEmptyPropertiesNull(value);
            else if (string.IsNullOrWhiteSpace((value ?? string.Empty).ToString()))
                property.SetValue(request, null);
        }
    
        return request;
    }
