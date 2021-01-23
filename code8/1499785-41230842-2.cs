    private int GetTypeHash<T>()
    {
    	var propertiesToCheck = typeof(T).GetProperties();
    
    	if(propertiesToCheck == null || propertiesToCheck.Length == 0)
    		return 0;
    
    	StringBuilder sb = new StringBuilder();
    
    	foreach(var propertyToCheck in propertiesToCheck)
    	{
			//Some simple things that could change:
			sb.Append((int)propertyToCheck.Attributes);
			sb.Append(propertyToCheck.CanRead);
			sb.Append(propertyToCheck.CanWrite);
			sb.Append(propertyToCheck.IsSpecialName);
			sb.Append(propertyToCheck.Name);
			sb.Append(propertyToCheck.PropertyType.AssemblyQualifiedName);
			//It might be an index property
			var indexParams = propertyToCheck.GetIndexParameters();
			if(indexParams != null && indexParams.Length != 0)
			{
				sb.Append(indexParams.Length);
			}
			//It might have custom attributes
			var customAttributes = propertyToCheck.CustomAttributes;
			if(customAttributes != null)
			{
				foreach(var cusAttr in customAttributes)
				{
					sb.Append(cusAttr.GetType().AssemblyQualifiedName);
				}
			}
    	}
    
    	return sb.ToString().GetHashCode();
    }
