    public class FilterRoutesDocumentFilter : IDocumentFilter
    {  
         public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
         {
              var keys = swaggerDoc.paths.Keys.Where(x => x.Contains("/api/Default/")).ToList();
               foreach (var key in keys)
                   swaggerDoc.paths.Remove(key);
         }
    }
