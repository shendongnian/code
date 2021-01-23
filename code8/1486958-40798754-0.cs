    public string ShowProperties<T>() : where T : class
    {
       var props = typeof (T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
    
        string typeInfo = typeof (T).FullName + Environment.NewLine;
        foreach (var prop in props)
        {
           typeInfo += prop.Name + " " + prop.PropertyType.FullName + Environment.NewLine;
        }
      return typeInfo;
    }
