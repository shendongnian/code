    public static T Cast<T>(Object obj) where T : class
    {
        var propertyInfo = obj.GetType().GetProperty("Instance");
        return propertyInfo == null ? null : propertyInfo.GetValue(obj, null) as T;
    }
