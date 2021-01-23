    public virtual object FromStream(string line)
    {
        string name, type;
    
        List<PropertyInfo> props = new List<PropertyInfo>(GetType().GetProperties()); 
    
        foreach (PropertyInfo prop in props)
        {
            type = prop.PropertyType.ToString();
            name = prop.Name;
    
            Console.WriteLine(name + " as " + type);
        }
        return null;
    }
