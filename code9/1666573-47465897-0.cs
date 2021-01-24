    IDictionary<string, object> myDict = new Dictionary<string, object>();
    myDict.Add("boolProp", true);
    myDict.Add("stringProp", "teststring");
    var s = new MyClass();
    var t = s.GetType();
    foreach (var values in myDict)
    {
        var p = t.GetProperty(values.Key, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        p.SetValue(s, values.Value);
    }
