    public static IEnumerable<PropertyInfo> GetPropertiesWithAttribute<TAttribute>(this Type type) where TAttribute : Attribute
    {
    	var properties = type.GetProperties();
    	// Find all attributes of type TAttribute for all of the properties belonging to the type.
    	foreach (PropertyInfo property in properties)
    	{
    		var attributes = property.GetCustomAttributes(true).Where(a => a.GetType() == typeof(TAttribute)).ToList();
    		if (attributes != null && attributes.Any())
    		{
    			yield return property;
    		}
    	}
    }
