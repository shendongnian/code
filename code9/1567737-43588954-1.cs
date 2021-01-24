    foreach (PropertyInfo propertyInfo in data.GetType().GetProperties())
    {
        if (propertyInfo.PropertyType == typeof(bool))
        {
            bool value = (bool)propertyInfo.GetValue(data, null);
            if(value)
            {
               //add propertyInfo to some result
            }
        }
    }            
