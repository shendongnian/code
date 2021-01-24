    class Foo
    {
        [JsonProperty("ids")]
        [JsonConverter(typeof(CustomArrayConverter<int>), "id")]
        public int[] MyIds { get; set; }
    }
