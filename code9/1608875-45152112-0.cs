        private class YamlDocumentFilter : IDocumentFilter
        {
            public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
            {
                string file = AppDomain.CurrentDomain.BaseDirectory + "swagger.yaml";
                if (!File.Exists(file))
                {
                    var serializer = new YamlDotNet.Serialization.Serializer();
                    using (var writer = new StringWriter())
                    {
                        serializer.Serialize(writer, swaggerDoc);
                        var stream = new StreamWriter(file);
                        stream.WriteLine(writer.ToString());
                    }
                }
            }
        }
