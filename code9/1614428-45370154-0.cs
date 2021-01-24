                var basepath = "/api/AppStatus";
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) => swaggerDoc.BasePath = basepath);
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) => {
                    IDictionary<string, PathItem> paths = new Dictionary<string, PathItem>();
                    foreach (var path in swaggerDoc.Paths)
                    {
                        paths.Add(path.Key.Replace(basepath, "/"), path.Value);
                    }
                    swaggerDoc.Paths = paths;
                });
