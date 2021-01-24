    var results =  JsonConvert.DeserializeObject<RootObject>(response.Content);   
    public class LineMatch
    {
        public int line { get; set; }
        public string context { get; set; }
        public string escaped { get; set; }
    }
    
    public class Match
    {
        public string field { get; set; }
        public string fieldLabel { get; set; }
        public List<LineMatch> lineMatches { get; set; }
        public int count { get; set; }
    }
    
    public class Hit
    {
        public string name { get; set; }
        public string className { get; set; }
        public string tableLabel { get; set; }
        public List<Match> matches { get; set; }
        public string sysId { get; set; }
        public long modified { get; set; }
    }
    
    public class Result
    {
        public string recordType { get; set; }
        public List<Hit> hits { get; set; }
        public string tableLabel { get; set; }
    }
    
    public class RootObject
    {
        public List<Result> result { get; set; }
    }
