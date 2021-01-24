    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        services.AddMvc().AddJsonOptions(config =>
        {
            // This prevents the json serializer from parsing dates
            config.SerializerSettings.DateParseHandling = DateParseHandling.None;
            // This changes how the timezone is converted - RoundtripKind keeps the timezone that was provided and doesn't convert it
            config.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind;
        });
    }
