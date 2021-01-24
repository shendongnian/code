    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class CaseToChange
    {
        public string StringProperty { get; set; } //Change to camelCase
        public SomeOtherType OtherTypeProperty { get; set; } //Change name of this to camelCase but not property name of "SomeOtherType"
    }
