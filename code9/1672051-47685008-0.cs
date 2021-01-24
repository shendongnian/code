    MyClass c = new MyClass();
    string val;
    if (c.PossiblyNullDictionary != null && c.PossiblyNullDictionary.TryGetValue("someKey", out val)) {
        Console.WriteLine(val); // now okay
    }
