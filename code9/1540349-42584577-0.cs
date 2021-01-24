    public class ThingToSerialize {
       [DefaultValue(false)]
       [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
       public bool SomeProperty { get; set; }
    }
