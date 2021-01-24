    var props = new Dictionary<string, Dictionary<string, int>>
                {
                    { "data", new Dictionary<string, int>
                              {
                                  {"prop1", 6},
                                  {"prop3", 7}
                              }
                    }
                };
    var json = JsonConvert.SerializeObject(props, Formatting.Indented);
