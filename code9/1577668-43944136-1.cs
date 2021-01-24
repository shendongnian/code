    services.AddMvc(options =>
    {
        options.OutputFormatters.RemoveType<JsonOutputFormatter>();
        options.OutputFormatters.Add(new NamedFormatJsonOutputFormatter(new JsonSerializerSettings(),
            
            new Dictionary<string, JsonSerializerSettings>()
            {
                {
                    "pretty", new JsonSerializerSettings()
                    {
                        Formatting = Formatting.Indented
                    }
                }
            }, ArrayPool<char>.Shared));
    });
