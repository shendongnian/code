    public void DoStuff(object currentObject)
    {
        //Lets see if our entity class has associated metadata
    	var metaDataAttribute = currentObject.GetType()
    		.GetCustomAttributes()
    		.SingleOrDefault(a => a is MetadataTypeAttribute) as MetadataTypeAttribute;
    
    	PropertyInfo[] metaProperties = null;
    	
        //Cache the metadata properties here
    	if (metaDataAttribute != null)
    	{
    		metaProperties = metaDataAttribute.MetadataClassType.GetProperties();
    	}
    	
        //As before loop through each property...
    	foreach (PropertyInfo propertyInfo in currentObject.GetType().GetProperties())
    	{
            //Refactored this out as it's called again later
    		ProcessAttributes(propertyInfo.GetCustomAttributes());
    
    		//Now check the metadata class
    		if (metaProperties != null)
    		{
                //Look for a matching property in the metadata class
    			var metaPropertyInfo = metaProperties
                    .SingleOrDefault(p => p.Name == propertyInfo.Name);
    			if (metaPropertyInfo != null)
    			{
    				ProcessAttributes(metaPropertyInfo.GetCustomAttributes());
    			}
    		}
    	}
    }
