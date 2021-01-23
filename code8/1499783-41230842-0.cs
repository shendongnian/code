    private int GetTypeHash<T>()
    {
    	var propertiesToCheck = typeof(T).GetProperties();
    
    	if(propertiesToCheck == null || propertiesToCheck.Length == 0)
    		return 0;
    
    	StringBuilder sb = new StringBuilder();
    
    	foreach(var propertyToCheck in propertiesToCheck)
    	{
    		sb.Append((int)propertyToCheck.Attributes);
    		sb.Append(propertyToCheck.CanRead);
    		sb.Append(propertyToCheck.CanWrite);
    		sb.Append(propertyToCheck.IsSpecialName);
    		sb.Append(propertyToCheck.Name);
    		sb.Append(propertyToCheck.PropertyType.AssemblyQualifiedName);
    	}
    
    	return sb.ToString().GetHashCode();
    }
