    private static object GetDummyObject(Type type)
    {
    	var	obj = Activator.CreateInstance(type);
    	if (obj != null)
    	{
    		var properties = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public);
    
    		foreach (var property in properties)
    		{
    			if (property.PropertyType == typeof(String))
    			{
    				property.SetValue(obj, property.Name.ToString(), null);
    			}
    			else if (property.PropertyType.IsArray)
    			{
    				property.SetValue(obj, Array.CreateInstance(type.GetElementType(), 0), null);
    			}
    			else
    			{
    				var o = GetDefault(property.PropertyType);
    				property.SetValue(obj, o, null);
    			}
    		}
    	}
    
    	return obj;
    }
