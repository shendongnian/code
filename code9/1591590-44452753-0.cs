    public class Root
    {
        [JsonProperty("test")]
        public Test Test { get; set; }
    }
    public class Test
    {
        [JsonProperty("object_array1")]
        public List<int> IntArray { get; set; }
        [JsonProperty("object_array2")]
        public List<string> StringArray { get; set; }
    }
