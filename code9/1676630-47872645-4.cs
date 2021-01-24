    public class RootObject
    {
        [JsonFormat("{0:c}", CulturePropertyName = nameof(Culture))]
        public decimal Cost { get; set; }
        [JsonIgnore]
        public CultureInfo Culture { get; set; }
        public string SomeValue { get; set; }
        public string SomeOtherValue { get; set; }
    }
