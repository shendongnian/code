    var foo = new Foo();
    //retrieve the propertyDictionary for the type
    for (var i = 0; i < dataReader.FieldCount; i++)
    {
        var n = dataReader.GetName(i);
        PropertyInfo prop;
        if (!propertyDictionary.TryGetValue(n, out prop)) continue;
        var val = dataReader.IsDBNull(i) ? null : dataReader.GetValue(i);
        prop.SetValue(foo, val, null);
    }
    return foo;
