    [JsonConverter(typeof(DateParseHandlingConverter), DateParseHandling.None)] // Disable Json.NET's built-in date time parsing function.
    public class RootObject
    {
        public DateTime pickupBefore { get; set; }
    }
