    public class AssignPropertyRequiredFilter : ISchemaFilter {
    
    	public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type type) {
    
    		var requiredProperties = type.GetProperties()
    			.Where(x => x.PropertyType.IsValueType)
    			.Select(t => char.ToLowerInvariant(t.Name[0]) + t.Name.Substring(1));
    
    		if (schema.required == null) {
    			schema.required = new List<string>();
    		}
    		schema.required = schema.required.Union(requiredProperties).ToList();
    	}
    }
