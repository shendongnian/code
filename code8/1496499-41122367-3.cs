    var jsonStr = JsonConvert.DeserializeObject<string>(data);
                    var genericEnum = JsonConvert.DeserializeObject<List<SOROCat>>(jsonStr, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto,
                        Formatting = Formatting.Indented
                    });
