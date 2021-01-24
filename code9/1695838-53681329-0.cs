    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class FeedItems {
      public string Name { get; set; } = string.Empty;
      public int Quantity { get; set; } = 0;
      public string OtherProperty { get; set; } = string.Empty;
    }
