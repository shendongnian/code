        private class RouteTestDocumentFilter : IDocumentFilter
        {
            const string PATH = "/api/RouteTest/test/{itemid}";
            public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry s, IApiExplorer a)
            {
                if (swaggerDoc.paths != null && swaggerDoc.paths.ContainsKey(PATH))
                {
                    var get = swaggerDoc.paths[PATH].get;
                    if (get != null)
                    {
                        get.parameters.RemoveAt(0);
                        get.parameters[0].@in = "path";
                        get.parameters[0].required = true;
                        foreach (var param in get.parameters)
                        {
                            int pos = param.name.IndexOf('.');
                            if (pos > 0)
                                param.name = param.name.Substring(pos + 1);
                        }
                    }
                }
            }
        }
