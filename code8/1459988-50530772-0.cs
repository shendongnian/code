        public class SwashbuckleOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (context.ApiDescription.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
            {
                operation.OperationId = $"{controllerActionDescriptor.ControllerName}_{operation.OperationId}";
            }
        }
    }
