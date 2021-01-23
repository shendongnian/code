    var settings = new JsonSerializerSettings();
    settings.Converters.Add(new StringEnumConverter());
    settings.NullValueHandling = NullValueHandling.Ignore;
    string json = JsonConvert.SerializeObject(emailObject, Newtonsoft.Json.Formatting.None, settings);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
