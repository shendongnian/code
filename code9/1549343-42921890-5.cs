    // Type namespace and name
    string typeName = typeof(OPCTag).FullName; // MyNamespace.OPCTag
    List<Object> list = new List<Object>();
    for (int i = 0; i < 10; i++)
    {
        // Create object dynamically from string type
        var obj = Type.GetType(typeName).GetConstructor(new Type[0]).Invoke(new object[0]);
        // Set value for 'tagName' property
        obj.GetType().GetProperty("tagName").SetValue(obj, "New value for 'tagName'");
        // Get value from 'tagName' property
        string tagNameValue = (string)obj.GetType().GetProperty("tagName").GetValue(obj);
        list.Add(obj);
    }
