       public class AddRequiredHeaderParameter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
                operation.parameters = new List<Parameter>();
            operation.parameters.Add(new Parameter
            {
                name = "X-User-Token",
                @in = "header",
                type = "string",
                required = false
            });
        }
    }
