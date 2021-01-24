    /// <summary>
    /// Makes all value-type properties "Required" in the schema docs, which is appropriate since they cannot be null.
    /// </summary>
    /// <remarks>
    /// This saves effort + maintenance from having to add <c>[Required]</c> to all value type properties; Web API, EF, and Json.net already understand
    /// that value type properties cannot be null.
    /// 
    /// More background on the problem solved by this type: https://stackoverflow.com/questions/46576234/swashbuckle-make-non-nullable-properties-required </remarks>
    public sealed class RequireValueTypePropertiesSchemaFilter : ISchemaFilter
    {
        private readonly CamelCasePropertyNamesContractResolver _camelCaseContractResolver;
    
        /// <summary>
        /// Initializes a new <see cref="RequireValueTypePropertiesSchemaFilter"/>.
        /// </summary>
        /// <param name="camelCasePropertyNames">If <c>true</c>, property names are expected to be camel-cased in the JSON schema.</param>
        /// <remarks>
        /// I couldn't figure out a way to determine if the swagger generator is using <see cref="CamelCaseNamingStrategy"/> or not;
        /// so <paramref name="camelCasePropertyNames"/> needs to be passed in since it can't be determined.
        /// </remarks>
        public RequireValueTypePropertiesSchemaFilter(bool camelCasePropertyNames)
        {
            _camelCaseContractResolver = camelCasePropertyNames ? new CamelCasePropertyNamesContractResolver() : null;
        }
    
        /// <summary>
        /// Returns the JSON property name for <paramref name="property"/>.
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        private string PropertyName(PropertyInfo property)
        {
            return _camelCaseContractResolver?.GetResolvedPropertyName(property.Name) ?? property.Name;
        }
    
        /// <summary>
        /// Adds non-nullable value type properties in a <see cref="Type"/> to the set of required properties for that type.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="context"></param>
        public void Apply(Schema model, SchemaFilterContext context)
        {
            foreach (var property in context.SystemType.GetProperties())
            {
                string schemaPropertyName = PropertyName(property);
                // This check ensures that properties that are not in the schema are not added as required.
                // This includes properties marked with [IgnoreDataMember] or [JsonIgnore] (should not be present in schema or required).
                if (model.Properties?.ContainsKey(schemaPropertyName) == true)
                {
                    // Value type properties are required,
                    // except: Properties of type Nullable<T> are not required.
                    var propertyType = property.PropertyType;
                    if (propertyType.IsValueType
                        && ! (propertyType.IsConstructedGenericType && (propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))))
                    {
                        // Properties marked with [Required] are already required (don't require it again).
                        if (! property.CustomAttributes.Any(attr =>
                                                            {
                                                                var t = attr.AttributeType;
                                                                return t == typeof(RequiredAttribute);
                                                            }))
                        {
                            // Make the value type property required
                            if (model.Required == null)
                            {
                                model.Required = new List<string>();
                            }
                            model.Required.Add(schemaPropertyName);
                        }
                    }
                }
            }
        }
    }
