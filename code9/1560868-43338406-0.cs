    // Get property array
    var properties = GetProperties(some_object);
    
    foreach (var p in properties)
    {
        string name = p.Name;
        var value = p.GetValue(some_object, null);
    }
    
    private static PropertyInfo[] GetProperties(object obj)
    {
        return obj.GetType().GetProperties();
    }
