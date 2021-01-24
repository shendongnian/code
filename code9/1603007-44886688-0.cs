    List<PropertyInfo> GetPropertiesRecursive(Type type)
    {
    	var properties = new List<PropertyInfo>
    	foreach(var propertyInfo in type.GetProperties())
    	{
    		properties.Add(propertyInfo);
    		if(!propertyInfo.PropertyType.IsValueType)
    		{
    			properties.AddRange(GetPropertiesRecursive(propertyInfo.PropertyType));
    		}
    	}
    	return properties;
    }
