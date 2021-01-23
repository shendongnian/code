    var type = typeof(Foo);
    var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
    var propertyDictionary = new Dictionary<string,PropertyInfo>();
    foreach(var property in properties)
    {
        if (!property.CanWrite) continue;
        propertyDictionary.Add(property.Name, property);
    }
