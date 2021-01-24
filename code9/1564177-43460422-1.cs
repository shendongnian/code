    public class DataAnnotationSchemaFilter : ISchemaFilter
    {
    	public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type type)
    	{
    		var propertyMappings = type
    			.GetProperties()
    			.Join(
    			    schema.properties ?? new Dictionary<string, Schema>(),
    			    x => x.Name.ToLower(),
    			    x => x.Key.ToLower(), 
    			    (x, y) => new KeyValuePair<PropertyInfo, KeyValuePair<string, Schema>>(x, y))
    			.ToList();
    
    		foreach (var propertyMapping in propertyMappings)
    		{
    			var propertyInfo = propertyMapping.Key;
    			var propertyNameToSchemaKvp = propertyMapping.Value;
    
    			foreach (var attribute in propertyInfo.GetCustomAttributes())
    			{
    				SetSchemaDetails(schema, propertyNameToSchemaKvp, propertyInfo, attribute);
    			}
    		}
    	}
    
    	private static void SetSchemaDetails(Schema parentSchema, KeyValuePair<string, Schema> propertyNameToSchemaKvp, PropertyInfo propertyInfo, object propertyAttribute)
    	{
    		var schema = propertyNameToSchemaKvp.Value;
    
    		if (propertyAttribute is DataTypeAttribute)
    		{
    			var dataType = ((DataTypeAttribute)propertyAttribute).DataType;
    			if (dataType == DataType.Date)
    				schema.type = "date";
    		}
    
    		if (propertyAttribute is ReadOnlyAttribute)
    		{
    			schema.readOnly = ((ReadOnlyAttribute)propertyAttribute).IsReadOnly;
    		}
    	}
    }
