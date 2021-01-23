    class ApplyModelNameFilter : ISchemaFilter
    {
        public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type type)
        {     
            schema.title = type.Name;
        }
    }
