    var settings = new JsonSerializerSettings()
    {
        DateParseHandling = DateParseHandling.DateTimeOffset,
        DateFormatHandling = DateFormatHandling.IsoDateFormat,
        DateTimeZoneHandling = DateTimeZoneHandling.Utc
    };
    var json = JToken.FromObject(foo, JsonSerializer.CreateDefault(settings));
    // Make modifications as required
    // json["foo"] = "bar";
    // Generate final JSON.
    var finalString = JsonConvert.SerializeObject(json, Formatting.Indented, settings);
