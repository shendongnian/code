    var settings = new JsonSerializerSettings
    {
        DateTimeZoneHandling = DateTimeZoneHandling.Utc,
    };
    var root = JsonConvert.DeserializeObject<RootObject>(json, settings);
