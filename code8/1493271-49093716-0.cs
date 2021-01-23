    public class SwaggerExcludeSchemaFilter : ISchemaFilter
    {
    	public void Apply(Schema schema, SchemaFilterContext context)
    	{
    		if (schema?.Properties == null)
    		{
    			return;
    		}
    
    		var excludedProperties = context.SystemType.GetProperties().Where(t => t.GetCustomAttribute<SwaggerExcludeAttribute>() != null);
    		foreach (PropertyInfo excludedProperty in excludedProperties)
    		{
    			if (schema.Properties.ContainsKey(excludedProperty.Name))
    			{
    				schema.Properties.Remove(excludedProperty.Name);
    			}
    		}
    	}
    }
