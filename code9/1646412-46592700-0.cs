    Type t = typeof(myType);
    FieldInfo[] arr = t.GetFields(BindingFlags.Public|BindingFligs.NonPublic);
    var newInstance = new myType();
    foreach (FieldInfo i in arr) 
    { 
        Console.WriteLine(i.GetValue(newInstance));
    }
