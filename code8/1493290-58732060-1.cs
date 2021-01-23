    public class SwaggerExcludeFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema model, SchemaFilterContext context)
        {
            var excludeProperties = context.ApiModel.Type?.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(SwaggerExcludeAttribute)));
            if (excludeProperties != null)
            {
                foreach (var property in excludeProperties)
                {
                    // Because swagger uses camel casing
                    var propertyName = $"{ToLowerInvariant(property.Name[0])}{property.Name.Substring(1)}";
                    if (model.Properties.ContainsKey(propertyName))
                    {
                        model.Properties.Remove(propertyName);
                    }
                }
            }
        }
    }
