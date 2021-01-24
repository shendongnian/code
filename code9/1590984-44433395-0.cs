        AccessRole instance = new AccessRole();
        //...
        Type type = typeof(AccessRole);
        
        // Loop over properties.
        foreach (PropertyInfo propertyInfo in type.GetProperties())
        {
            string name = propertyInfo.Name;
            object value = propertyInfo.GetValue(instance, null);
            if (value is bool and (bool)value)
            {
                // print...
            }
        }
    
