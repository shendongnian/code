    var settings = new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.Auto,
        Converters =
        {
            new IsoDateTimeConverter
            {
                DateTimeStyles = DateTimeStyles.RoundtripKind
            }
        }
    };
    var serialization = endpointConfiguration.UseSerialization<NewtonsoftSerializer>();
    serialization.Settings(settings);
