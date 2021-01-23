    public class SwaggerExcludeFilter : ISchemaFilter
    {
        #region ISchemaFilter Members
        public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type type)
        {
            if (schema?.Properties == null || type == null)
                return;
            var excludedProperties = type.GetProperties()
                                         .Where(t => 
                                                t.GetCustomAttribute<SwaggerExcludeAttribute>() 
                                                != null);
            foreach (var excludedProperty in excludedProperties)
            {
                if (schema.properties.ContainsKey(excludedProperty.Name))
                    schema.properties.Remove(excludedProperty.Name);
            }
        }
        #endregion
    }
