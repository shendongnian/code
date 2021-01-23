    public class Result
    {
        public string url { get; set; }
        public string name { get; set; }
    }
    
    public class RootObject
    {
        public int count { get; set; }
        public object previous { get; set; }
        public List<Result> results { get; set; }
    }
    var  results = JsonConvert.DeserializeObject<RootObject>(json);
