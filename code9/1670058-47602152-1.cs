    public static void MyMethod(String words, Object obj)
    {
        if (obj == null)
            throw new ArgumentNullException("obj");
        Type objType = obj.GetType();
    
        Logger.Log("Object of Type '" + objType.ToString() + "' logged. Properties:");
    
        List<PropertyInfo> props = new List<PropertyInfo>(objType.GetProperties());
    
        foreach (PropertyInfo prop in props)
        {
            Object propValue = prop.GetValue(obj, null);
            Logger.Log("  - " + prop.Name + " (" + propValue.GetType().ToString() + ") = " + propValue.ToString());
        }
    
        connection.Open();
        connection.Execute(words, obj);
    }
