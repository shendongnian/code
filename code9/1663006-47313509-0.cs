    PropertyInfo[] props = T.GetType().GetProperties();
    
    foreach(var prop in props)
    {
        string propName = prop.GetMethod.Name;
        if (args.ContainsKey(propName))
        {
            prop.SetValue(returnedObject, args[propName]);
        }
    }
