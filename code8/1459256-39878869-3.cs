    public static bool IsEnumerable(PropertyInfo propertyInfo)
    {
    	var propType = propertyInfo.PropertyType;
    
    	var ienumerableInterfaces = propType.GetInterfaces()
    			.Where(x => x.IsGenericType && x.GetGenericTypeDefinition() ==
                            typeof(IEnumerable<>)).ToList();
    
    	if (ienumerableInterfaces.Count == 0) return false;
    
    	return ienumerableInterfaces.All(x => 
    				x.GenericTypeArguments[0] != typeof(string) &&
    				!x.GenericTypeArguments[0].IsValueType);	
    }
