    public class Item
    {
        public float[][] entries { get; set; }
    }
    var serialized = "{\"entries\":[[0,0.26],[50000,0.24],[100000,0.22],[250000,0.2]]}";
    var deserialized = Newtonsoft.Json.JsonConvert.DeserializeObject<Item>(serialized);
