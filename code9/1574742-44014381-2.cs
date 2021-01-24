    using Swashbuckle.Swagger;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Description;
    
    namespace YourSpace
    {
		public class AttachRouteNameFilter : IOperationFilter
		{
			public void Apply(Operation operation, 
				SchemaRegistry schemaRegistry, 
				ApiDescription apiDescription)
			{
				string routeName = apiDescription
					?.GetControllerAndActionAttributes<RouteAttribute>()
					?.FirstOrDefault()
					?.Name;
		
				operation.summary = string.Join(" - ", new[] { routeName, operation.summary }
                   .Where(x => !string.IsNullOrWhiteSpace(x)));
			}
		}
    }
