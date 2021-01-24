    public class JsonObject
    {
        public string answer { get; set; }
        public string hash { get; set; }
        public string name { get; set; }
        public int kills { get; set; }
        public int online { get; set; }
        public string currentTime { get; set; }
        public string endDate { get; set; }
        public string configUrl { get; set; }
        public List<object> extend { get; set; }
    }
    var json = JsonConvert.DeserializeObject<JsonObject>(jsonStr);
    Console.WriteLine(json.answer);
