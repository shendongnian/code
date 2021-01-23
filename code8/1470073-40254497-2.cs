    private static string GenerateStr<T>(IList<T> obj, string propName)
    {
        var propertyInfo = typeof(T).GetProperty(propName);
        return obj.Aggregate(string.Empty, (current, o) => current + propertyInfo.GetValue(o, null));
    }
