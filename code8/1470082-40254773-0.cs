    static string GenerateStrReflection<T>(IList<T> obj, string propName)
    {
        var property = typeof(T).GetProperty(propName);
    
        return string.Concat(obj.Select(o => property.GetValue(o)));
    }
