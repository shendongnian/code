    public class HideInDocsFilter:IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer, IHostingEnvironment env)
        {
            if(env.IsEnvironment("Production")) {
                foreach (var apiDescription in apiExplorer.ApiDescriptions)
                {
                    if (!apiDescription.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<HideInDocsAttribute>().Any() && !apiDescription.ActionDescriptor.GetCustomAttributes<HideInDocsAttribute>().Any()) continue;
                    var route = "/" + apiDescription.Route.RouteTemplate.TrimEnd('/');
                    swaggerDoc.paths.Remove(route);
                }
            }            
        }
    }
