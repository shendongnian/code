    public static void CloneProperties<T>(T original, T destination)    
    {
        PropertyInfo[] props = typeof(T).GetProperties();
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
                    propertyInfo.SetValue(destination, pv, null);
                }
             }
        }
    }
