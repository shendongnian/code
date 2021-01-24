    public class Data
    {
        [JsonProperty(Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string NullableVariable { get; set; }
    }
