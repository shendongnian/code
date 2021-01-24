    services.AddMvc().AddJsonOptions(options =>
    {
        // NodaConverters lives in the NodaTime.Serialization.JsonNet assembly
        options.SerializerSettings.Converters.Add(NodaConverters.LocalDateConverter);
    });
