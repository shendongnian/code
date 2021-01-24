    [JsonConverter(typeof(FloatParseHandlingConverter), FloatParseHandling.Decimal)]
    public class Parent
    {
        // [JsonConverter(typeof(FloatParseHandlingConverter), FloatParseHandling.Decimal)] will not work
        dynamic value { get; set; }
    }
