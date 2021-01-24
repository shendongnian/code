    Type types = typeof(ModelName);
    
    //Loop through each properties inside class and get values for the property from both the objects and compare
    foreach (System.Reflection.PropertyInfo property in types.GetProperties())
    {
    	string newValue = string.Empty;
    	string oldValue = string.Empty;
    	if (types.GetProperty(property.Name).GetValue(modelnew, null) != null)
    		newValue = types.GetProperty(property.Name).GetValue(modelnew, null).ToString();
    	if (types.GetProperty(property.Name).GetValue(modelOld, null) != null)
    		oldValue = types.GetProperty(property.Name).GetValue(modelOld, null).ToString();
    
    	if (newValue.Trim() != oldValue.Trim()) //if both values are not same
    	{
    		if (!string.IsNullOrEmpty(newValue.Trim()) && !string.IsNullOrEmpty(oldValue.Trim()))//if both values are not null
    		{
    			//log the update ie. value is updated from oldValue to newValue
    		}
    		else if (!string.IsNullOrEmpty(oldValue.Trim()))//else if only oldvalue is not null
    		{
    			//log - oldvalue has been deleted for property.name
    		}
    		else if (!string.IsNullOrEmpty(newValue.Trim()))
    		{
    			//log- newValue has been added for property.name
    		}
    	}
    }
