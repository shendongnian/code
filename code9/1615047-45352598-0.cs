    foreach(Type type in assembly.GetTypes())
    {
        var attr = assembly.GetCustomAttribute<Method>();
        if (attr!=null)
        {
            animals.Add(attr.Name, type);
        }
    }
