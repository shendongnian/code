    public static void MyMethod(String words, Object obj)
    {
        if (obj == null)
            throw new ArgumentNullException("obj");
        Type objType = obj.GetType();
        List<PropertyInfo> props = new List<PropertyInfo>(objType.GetProperties());
    
        Logger.Log(
            "Object of Type '{0}' with properties:",
            objType.ToString()
        );
        foreach (PropertyInfo prop in props)
        {
            Logger.Log("  - {0} [Type = {1}] [Value = {2}]",
                prop.Name,
                prop.PropertyType,
                prop.GetValue(this, null)
            );
        }
    
        connection.Open();
        connection.Execute(words, obj);
    }
