    public class CaseToChange
    {
        [JsonProperty("stringProperty")]
        public string StringProperty { get; set; } //Change to camelCase
        [JsonProperty("otherTypeProperty")]
        public SomeOtherType OtherTypeProperty { get; set; } //Change name of this to camelCase but not property name of "SomeOtherType"
    }
