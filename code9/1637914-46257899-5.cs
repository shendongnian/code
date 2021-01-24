    public static bool IsParseable(this Type type) 
    {
        var argumentTypes = new[] { typeof(string) };        
        return type.GetRuntimeMethod("Parse", argumentTypes) != null;
    }
