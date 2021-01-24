    services.AddMvc()
        .AddJsonOptions(o => 
        {
            o.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        });
