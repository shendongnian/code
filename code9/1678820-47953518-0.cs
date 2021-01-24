    Type t = obj.GetType();
    PropertyInfo propInfo = t.GetProperty("article");
    if (propInfo.PropertyType == typeof(string))
    {
        Console.WriteLine("String Type");
    }
    if (propInfo.PropertyType == typeof(decimal))
    {
        Console.WriteLine("Decimal Type");
    }
