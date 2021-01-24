    public static bool IsParseable<T>() 
    {
        var argumentTypes = new[] { typeof(string) };
        var type = typeof(T);
        
        return type.GetRuntimeMethod("Parse", argumentTypes) != null;
    }
    // Use it
    if (IsParseable<decimal>())
    {
        // Parse...
    }
