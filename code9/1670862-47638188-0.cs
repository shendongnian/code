    public static IEnumerable<string> GetColumns<TEntity>(string modelName)
    {
    	var property = typeof(TEntity)
    		.GetProperties()
    		.Single(s => s.Name == modelName);
    		
    	return property.PropertyType
            .GetGenericArguments() //Get the generic type of the DbSet
    		.SelectMany(t => t.GetProperties()
    			.Select(pi => pi.Name));
    }
