        private class ApplySchemaVendorExtensions : ISchemaFilter
        {
            public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type type)
            {
                // Modify the example values in the final SwaggerDocument
                //
                if (schema.properties != null)
                {
                    foreach (var p in schema.properties)
                    {
                        switch (p.Value.format)
                        {
                            case "int32":
                                p.Value.example = 123;
                                break;
                            case "double":
                                p.Value.example = 9858.216;
                                break;
                        }
                    }
                }
            }
        }
_
        private class ApplyDocumentVendorExtensions : IDocumentFilter
        {
            public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
            {
                schemaRegistry.GetOrRegister(typeof(ExtraType));
                //schemaRegistry.GetOrRegister(typeof(BigClass));
                var paths = new Dictionary<string, PathItem>(swaggerDoc.paths);
                swaggerDoc.paths.Clear();
                foreach (var path in paths)
                {
                    if (path.Key.Contains("foo"))
                        swaggerDoc.paths.Add(path);
                }
            }
        }
