    public static void Meth1(object obj, string propertyName)
    {
        var prop = obj.GetType().GetProperty(propertyName);
        var value = prop.GetValue(obj);
        ...
    }
