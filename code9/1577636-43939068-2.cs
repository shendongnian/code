    public static T GetStaticPropertyValue<T>(Type type, string name) where T : class
    {
        foreach (var property in type.GetProperties())
        {
            if (property.Name == name)
            {
                return property.GetValue(null) as T;
            }
        }
        return null;
    }
