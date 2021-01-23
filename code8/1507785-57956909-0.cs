private class AddAuthorizationHeaderParameter: IOperationFilter   // as a nested class in script config file.
        {
            public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
            {
                if (operation.parameters == null)
                    operation.parameters = new List<Parameter>();
                operation.parameters.Add(new Parameter
                {
                    name = "Authorization",
                    @in = "header",
                    type = "string",
                    required = true
                });
            }
        }
c.OperationFilter<AddAuthorizationHeaderParameter>(); // finally add this line in .EnableSwagger
You can also add any no of headers for header implementation in Swagger. 
