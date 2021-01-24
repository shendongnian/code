        public class RequestModelExtentionOperator: IOperationFilter    
            {                 
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.operationId == "Controller_ActionName")  // controller and action name
            {
               var refSchema = schemaRegistry.GetOrRegister(typeof(List<ImageFeature>));
                    //here you can create a new Parameter of type Array
    var param=new Parameter 
                        {
                            name = "Features",
                            @in = "formData",
                            required = true,
                            type = "array"
                        };
                param.PopulateFrom(schema);
    operation.parameters = new[]{ param };
            }
        }            
                }
        }
