    var settings = new JsonSerializerSettings
    {
        NullValueHandling = NullValueHandling.Ignore,
        MissingMemberHandling = MissingMemberHandling.Ignore,
        Converters = { new ReturnNullConverter<CustomResponse>() },
    };
    var customResponse = JsonConvert.DeserializeObject<CustomResponse>(jsonString, settings);
