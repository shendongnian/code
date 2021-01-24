    public class Log
    {
        public List<Dictionary<string,string>> LogEntry { get; set; }
    }
    var log = JsonConvert.DeserializeObject<Log>(json);
