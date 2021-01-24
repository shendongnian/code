    // Type namespace and name
    string typeName = typeof(OPCTag).FullName; // MyNamespace.OPCTag
    List<Object> list = new List<Object>();
    for (int i = 0; i < 10; i++)
    {
        // Create object dynamically from type as string
        var obj = Type.GetType(typeName).GetConstructor(new Type[0]).Invoke(new object[0]);
        list.Add(obj);
    }
