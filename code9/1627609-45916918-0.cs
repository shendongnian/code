    using Swashbuckle.Swagger;    
    public class ApplySchemaVendorExtensions : ISchemaFilter
    {
        public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type type)
        {
            if (schema.properties != null)
            {
                if (type == typeof(TestModel))
                {
                    schema.example = new TestModel()
                    {
                        Id = 1,
                        Text = "Custom text value"
                    };
                }
            }
        }
    }
