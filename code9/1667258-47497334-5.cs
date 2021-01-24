    services.AddMvcCore()
        .AddJsonFormatters(o =>
        {
            o.ContractResolver = new CamelCasePropertyNamesContractResolver();
            o.NullValueHandling = NullValueHandling.Ignore;
        });
