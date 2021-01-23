    public class AddRequiredHeaderParameter : IOperationFilter
        {
            void IOperationFilter.Apply(Operation operation, OperationFilterContext context)
            {
                var param = new Param();
                param.Name = "JWT header";
                param.In = "header";
                param.Description = "JWT Token";
                param.Required = true;
                param.Type = "string";
                if (operation.Parameters == null)
                    operation.Parameters = new List<IParameter>();
                operation.Parameters.Add(param);
            }
        }
