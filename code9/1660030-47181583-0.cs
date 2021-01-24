    PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    foreach (PropertyInfo property in properties)
    {
       if (property.PropertyType == typeof(Parent)) 
       {
           object propertyValue = property.GetValue(obj);
           if (propertyValue != null)
           {
              // Get the deep clone of the field in the original object and assign the clone to the field in the new object.
              property.SetValue(copiedObject, CloneProcedure(propertyValue));
           }
       }
    }
