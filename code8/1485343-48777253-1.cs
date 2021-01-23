    public void ConfigureServices(IServiceCollection services)
    {
    
            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            options.OutputFormatters.RemoveType<JsonOutputFormatter>();
            options.OutputFormatters.Add(new WrappedJsonOutputFormatter(jsonSettings, ArrayPool<char>.Shared));
    }
