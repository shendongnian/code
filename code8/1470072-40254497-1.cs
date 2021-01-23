    private static string GenerateStr<T>(IList<T> obj, string propName)
    {
        var propertyInfo = typeof(T).GetProperty(propName);
        string str = string.Empty;
    
        foreach(var o in obj)
        {
            str += propertyInfo.GetValue(o, null);
        }
    
        return str;
    }
