    services.AddMvc()
      .AddJsonOptions( options =>
      {
        options.SerializerSettings.Formatting = Formatting.Indented;
        options.SerializerSettings.TypeNameHandling = TypeNameHandling.Objects;
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        options.SerializerSettings.Converters.Add(new StringEnumConverter());
      });
    
