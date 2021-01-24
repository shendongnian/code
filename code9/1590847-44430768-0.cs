    var settings = new JsonSerializerSettings()
    {
        DateParseHandling = DateParseHandling.DateTimeOffset,
        DateFormatHandling = DateFormatHandling.IsoDateFormat,
        DateTimeZoneHandling = DateTimeZoneHandling.Utc
    };
    // Generate initial serialization
    var initialString = JsonConvert.SerializeObject(foo, settings);
    // Parse back to JToken
    var json = JsonConvert.DeserializeObject<JObject>(initialString, settings);
    // Make modifications as required
    // json["foo"] = "bar";
    // Generate final JSON.
    var finalString = JsonConvert.SerializeObject(json, Formatting.Indented, settings);
