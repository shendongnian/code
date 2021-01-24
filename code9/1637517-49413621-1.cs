    public class EnumFilter : ISchemaFilter
    {
        public void Apply(Schema model, SchemaFilterContext context)
        {
            if (model == null)
                throw new ArgumentNullException("model");
            if (context == null)
                throw new ArgumentNullException("context");
            if (context.SystemType.IsEnum)
                model.Extensions.Add("x-ms-enum", new
                {
                    name = context.SystemType.Name,
                    modelAsString = false
                });
        }
    }
