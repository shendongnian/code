    public class SwaggerExcludeSchemaFilter : ISchemaFilter
    {
        public void Apply(Schema schema, SchemaFilterContext context)
        {
            if (schema?.Properties == null)
            {
                return;
            }
            var excludedProperties = 
                context.SystemType.GetProperties().Where(
                    t => t.GetCustomAttribute<SwaggerExcludeAttribute>() != null);
            foreach (var excludedProperty in excludedProperties)
            {
                var propertyToRemove =
                    schema.Properties.Keys.SingleOrDefault(
                        x => x.ToLower() == excludedProperty.Name.ToLower());
                if (propertyToRemove != null)
                {
                    schema.Properties.Remove(propertyToRemove);
                }
            }
        }
    }
