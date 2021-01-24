    public class Hero
    {
      [JsonProperty(PropertyName = "id")]
      public int Id { get; set; }
      [JsonProperty(PropertyName = "name")]
      public string Name { get; set; }
    }
