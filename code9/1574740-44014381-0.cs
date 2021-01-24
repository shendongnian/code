    using Swashbuckle.Swagger;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Description;
    
    namespace YourSpace
    {
        public class AttachRouteNameFilter : IOperationFilter
        {
            public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
            {
                var attributes = apiDescription.GetControllerAndActionAttributes<RouteAttribute>();
    
                string routeName = attributes?.FirstOrDefault()?.Name;
    
                if (!string.IsNullOrWhiteSpace(routeName))
                {
                    if (!string.IsNullOrWhiteSpace(operation.summary))
                    {
                        operation.summary = $"{routeName} - {operation.summary}";
                    }
                    else
                    {
                        operation.summary = $"{routeName}";
                    }
                }
            }
        }
    }
