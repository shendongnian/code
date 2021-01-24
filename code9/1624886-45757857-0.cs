    private class DocumentFilterAddFakes : IDocumentFilter
    {
        private PathItem FakePathItem(int i)
        {
            var x = new PathItem();
            x.get = new Operation()
            {
                tags = new[] { "Fake" },
                operationId = "Fake_Get" + i.ToString() ,
                consumes = null,
                produces = new[] { "application/json", "text/json", "application/xml", "text/xml" },
                parameters = new List<Parameter>()
                            {
                                new Parameter()
                                {
                                    name = "id",
                                    @in = "path",
                                    required = true,
                                    type = "integer",
                                    format = "int32",
                                    @default = 8
                                }
                            },
            };
            x.get.responses = new Dictionary<string, Response>();
            x.get.responses.Add("200", new Response() { description = "OK", schema = new Schema() { type = "string" } });
            return x;
        }
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            for (int i = 0; i < 10; i++)
                swaggerDoc.paths.Add("/Fake/" + i  + "/{id}", FakePathItem(i));
        }
    }
 
