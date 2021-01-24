    public static bool IsParseable<T>() 
    {
        var typeArray = { typeof(string) };
        var type = typeof(T);
        
        return type.GetRuntimeMethod("Parse", typeArray) != null;
    }
    // Use it
    if (IsParseable<decimal>())
    {
        // Parse...
    }
