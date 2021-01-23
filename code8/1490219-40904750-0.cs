    public static void Main(string[] args)
    {
        string json = @"[{ ""_id"":""xxx"", ""firstName"":""Brayann""}, { ""_id"":""yyy"", ""firstName"":""Peter""}]";
        var result = JsonConvert.DeserializeObject<List<RootListObject>>(json)
                                 .ToDictionary(x=> x.id, y=> y.firstName);
    }
    public class RootListObject
    {
        [JsonProperty(PropertyName ="_id")]
        public string id { get; set; }
        public string firstName { get; set; }
    }
