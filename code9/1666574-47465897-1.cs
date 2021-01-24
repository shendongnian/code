    IDictionary<string, string> myDict = new Dictionary<string, string>();
    myDict.Add("boolProp", "true");
    myDict.Add("stringProp", "teststring");
    var s = new MyClass();
    var t = s.GetType();
    foreach (var values in myDict)
    {
        var p = t.GetProperty(values.Key, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        var c = TypeDescriptor.GetConverter(p.PropertyType);
        var convertedValue = c.ConvertFromInvariantString(values.Value);
        p.SetValue(s, convertedValue);
    }
