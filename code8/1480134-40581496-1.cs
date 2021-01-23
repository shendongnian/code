    public override void OnMessage(string message)
    {
        MyData obj = JsonConvert.DeserializeObject<MyData>(message);
        string serverName = obj.Name;
        string serverPrice = obj.Price;
        ...
    }
    public class MyData
    {
        // Important: these JsonProperty attributes MUST match
        // the names of the properties in the client object
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("price")]
        public string Price { get; set; }
    }
