    /// <summary>
    /// Nonsense class just to represent your data. You'd implement the JsonConverter
    /// attribute on your own model class.
    /// </summary>
    public class Sample {
        [JsonConverter(typeof(TimezonelessDateTimeConverter))]
        public DateTime EventDate { get; set; }
    }
    //
    // And a sample of the actual deserialisation...
    ///
    var json = "{ \"EventDate\": \"2017-05-05T11:35:44-07:00\" }";
    var settings = new JsonSerializerSettings {
        DateParseHandling = DateParseHandling.DateTimeOffset
    };
    var deserialised = JsonConvert.DeserializeObject<Sample>(json, settings);
    Console.WriteLine(deserialised.EventDate);
