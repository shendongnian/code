    public class FormatSchemaProvider : JSchemaGenerationProvider
    {
        public override JSchema GetSchema(JSchemaTypeGenerationContext context)
        {
            // customize the generated schema for these types to have a format
            if (context.ObjectType == typeof(MyGenericClass<bool>))
            {
                return CreateSchemaWithFormat(
                   context.ObjectType, context.Required, "MyGenericClass");
            }
            // use default schema generation for all other types
            return null;
        }
    
        private JSchema CreateSchemaWithFormat(Type type, Required required, string format)
        {
            JSchemaGenerator generator = new JSchemaGenerator();
            JSchema schema = generator.Generate(type, required != Required.Always);
            schema.Format = format;
            return schema;
        }
    }
