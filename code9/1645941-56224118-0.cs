    public class AssignPropertyRequiredFilter : ISchemaFilter
    {
        public void Apply(Schema schema, SchemaFilterContext context)
        {
            if (schema.Properties == null || schema.Properties.Count == 0)
            {
                return;
            }
            var typeProperties = context.SystemType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in schema.Properties)
            {
                if (IsSourceTypePropertyNullable(typeProperties, property.Key))
                {
                    continue;
                }
                // "null", "boolean", "object", "array", "number", or "string"), or "integer" which matches any number with a zero fractional part.
                // see also: https://json-schema.org/latest/json-schema-validation.html#rfc.section.6.1.1
                switch (property.Value.Type)
                {
                    case "boolean":
                    case "integer":
                    case "number":
                        AddPropertyToRequired(schema, property.Key);
                        break;
                    case "string":
                        switch (property.Value.Format)
                        {
                            case "date-time":
                            case "uuid":
                                AddPropertyToRequired(schema, property.Key);
                                break;
                        }
                        break;
                }
            }
        }
        private bool IsNullable(Type type)
        {
            return Nullable.GetUnderlyingType(type) != null;
        }
        private bool IsSourceTypePropertyNullable(PropertyInfo[] typeProperties, string propertyName)
        { 
            return typeProperties.Any(info => info.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase)
                                            && IsNullable(info.PropertyType));
        }
        private void AddPropertyToRequired(Schema schema, string propertyName)
        {
            if (schema.Required == null)
            {
                schema.Required = new List<string>();
            }
            if (!schema.Required.Contains(propertyName))
            {
                schema.Required.Add(propertyName);
            }
        }
    }
