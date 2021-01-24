    private class DocumentFilterAddFakes : IDocumentFilter
    {
        private PathItem FakePathItem(int i)
        {
            var x = new PathItem();
            x.Get = new Operation()
            {
                Tags = new[] { "Fake" },
                OperationId = "Fake_Get" + i.ToString(),
                Consumes = null,
                Produces = new[] { "application/json", "text/json", "application/xml", "text/xml" },
                Parameters = new List<IParameter>()
                        {
                            new NonBodyParameter() // Can also be BodyParameter
                            {
                                Name = "id",
                                @In = "path",
                                Required = true,
                                Type = "integer",
                                Format = "int32",
                                @Default = 8
                            }
                        },
            };
            x.Get.Responses = new Dictionary<string, Response>();
            x.Get.Responses.Add("200", new Response() { Description = "OK", Schema = new Schema() { Type = "string" } });
            return x;
        }
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            for (int i = 0; i < 10; i++)
                swaggerDoc.paths.Add("/Fake/" + i  + "/{id}", FakePathItem(i));
        }
    }
 
