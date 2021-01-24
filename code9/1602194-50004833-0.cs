    var icollections = new List<string>();
    
    foreach (PropertyInfo property in
    	typeof(YourProjectName.ContextObject).Assembly
    	.GetType("YourProjectName.Entities." + Model.ModelTypeName)
    	.GetProperties())
    {
    	if (property.PropertyType.IsGenericType 
    		&& property.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
    	{
    		icollections.Add(property.Name);
    	}
    }
