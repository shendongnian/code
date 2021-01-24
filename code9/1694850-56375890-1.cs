    public class ExplictObsoleteRoutes : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
             if (operation.OperationId.EndsWith("ByOrderIdGet")"))
             {	
                 operation.Deprecated = true;
             }
        }
    }
