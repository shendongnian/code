    public class Item
    {
        [JsonProperty("entries")]
        public List<List<double>> Entries { get; set; }
    }
    var json = "{ 'entries':[[0,0.26],[50000,0.24],[100000,0.22],[250000,0.2]] }";
    var item = JsonConvert.DeserializeObject<Item>(json);
