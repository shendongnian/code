    public class Datum
    {
        [JsonProperty("dd")]
        public string dd;
        [JsonProperty("max")]
        public int max;
        [JsonProperty("min")]
        public int min;
        [JsonProperty("avg")]
        public int avg;
    }
    public class MyDocument : Document
    {
        [JsonProperty("id")]
        public string id;
        [JsonProperty("data")]
        public Datum[] data;
    }
