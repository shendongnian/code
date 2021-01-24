    public class VersionFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            swaggerDoc.paths = swaggerDoc.paths
                .ToDictionary(
                    path => path.Key.Replace("v{version}", swaggerDoc.info.version),
                    path => path.Value
                );
        }
    }
    public class VersionOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var version = operation.parameters?.FirstOrDefault(p => p.name == "version");
            if (version != null)
            {
                operation.parameters.Remove(version);
            }
        }
    }
  
