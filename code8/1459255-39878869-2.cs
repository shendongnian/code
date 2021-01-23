    private bool IsEnumerable(PropertyInfo propertyInfo)
    {	
    	return propertyInfo.PropertyType.GetInterfaces().Contains(typeof(IEnumerable)) &&
    		propertyInfo.PropertyType.GenericTypeArguments.Length > 0 &&
    		propertyInfo.PropertyType.GenericTypeArguments[0] != typeof(string) &&
    		!propertyInfo.PropertyType.GenericTypeArguments[0].IsValueType;
    }
