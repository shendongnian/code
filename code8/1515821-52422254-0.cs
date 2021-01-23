    internal class SwaggerFilterOutControllers : IDocumentFilter
        {
            void IDocumentFilter.Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
            {
                foreach (var item in swaggerDoc.paths.ToList())
                {
                    if (!(item.Key.ToLower().Contains("/api/v1/xxxx") ||
                        item.Key.ToLower().Contains("/api/v1/yyyy")))
                    {
                        swaggerDoc.paths.Remove(item.Key);
                    }
                }
            }
        }
