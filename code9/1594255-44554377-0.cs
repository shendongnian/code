    public static void CloneProperties<T>(T original, T destination)    
    {
        var originalType = original.GetType();
        var destinationType = destination.GetType();
    
        PropertyInfo[] props = originalType.GetProperties();
        foreach (var propertyInfo in props)
        {
            if (propertyInfo.PropertyType.Namespace == "System" || propertyInfo.PropertyType.IsEnum)
            {
                // ....
            }
            else
            {
                if (destination.PropertyHasCustomAttribute (propertyInfo.Name, typeof(EntityLookupAttribute)))
                {
                    var pv = propertyInfo.GetValue(original, null);
                    var destinationProperty = destinationType.GetProperty(propertyInfo.Name);
                    destinationProperty.SetValue(destination, pv, null);
                }
             }
        }
    }
