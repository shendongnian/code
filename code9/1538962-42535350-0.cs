    // Get all properties of our entity
    List<PropertyInfo> ourEntityProperties = new List<PropertyInfo>();
    foreach (var property in entity.GetType().GetProperties())
    {
        // check whether it only belongs to the child
    	if (property.DeclaringType.Equals(entity.GetType())) 
    	{
    		ourEntityProperties.Add(property);
    	}    	
    }
