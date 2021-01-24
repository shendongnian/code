    public T FromTags<T>(this List<Tag> tags)
    	where T : new()
    {
    	var t = new T();
    	
    	var properties = typeof(T).GetProperties();
    	
    	foreach (var tag in tags)
    	{
    		var property = properties.SingleOrDefault(p => p.Name == tag.name);
    
    		if (property != null)
    		{
    			property.SetValue(t, tag.value);
    		}
    	}
    	
    	return t;
    }
