    public static IEnumerable<PropertyInfo> PropertiesThatContainText<T>(T obj, string text, StringComparison comparison = StringComparison.Ordinal)
    {
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
           .Where(p => p.PropertyType == typeof(string) && p.CanRead);
        foreach (PropertyInfo prop in properties)
        {
            string propVal = (string)prop.GetValue(obj, null);
            if (String.Equals(text, propVal, comparison)) yield return prop;
        }
    }
