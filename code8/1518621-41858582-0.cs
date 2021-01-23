    private T SetNullStringToDefault<T>(T entity, string default)
    {
    	List<PropertyInfo> properties = entity.GetType().GetProperties().ToList();
    	foreach(var property in properties)
    	{
    		//if property is string
    		if(property.PropertyType == typeof(string))
    		{
    			string value = property.GetValue(entity, null) as string;
    			if (string.IsNullOrEmpty(value))
    				property.SetValue(entity, default, null);
    		}
    	}
    	return entity;
    }
