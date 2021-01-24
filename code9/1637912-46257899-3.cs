    public static bool IsParseable(this Type type) 
    {
        var typeArray = { typeof(string) };        
        return type.GetRuntimeMethod("Parse", typeArray) != null;
    }
