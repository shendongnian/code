    if (prop.PropertyType.IsClass)
    {
        PropertyInfo[] props = prop.PropertyType.GetProperties();
        var propValue = prop.GetValue(contact, null);
        foreach (PropertyInfo propint in props)
        {
            if (propint.PropertyType == typeof(string) && propint.GetValue(propValue, null) == null)
            {
                propint.SetValue(propValue, "");
            }
        }
    }
