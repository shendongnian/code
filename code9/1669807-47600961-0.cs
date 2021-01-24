        public class AddRequiredHeaderParameters : IOperationFilter
        {
            public void Apply(Operation operation, SchemaRegistry s, ApiDescription a)
            {
                if (operation.operationId == "ControllerName_Upload")
                {
                    if (operation.parameters == null)
                        operation.parameters = new List<Parameter>();
                    operation.parameters.Add(
                        new Parameter
                        {
                            name = "bigupload",
                            @in = "body",
                            @default = "123",
                            type = "string",
                            description = "bla bla",
                            required = true
                        }
                    );                    
                }
            }
        }
           
