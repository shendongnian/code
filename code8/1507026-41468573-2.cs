    public class Result
    {
        public string symbol { get; set; }
        public string name { get; set; }
        public string exch { get; set; }
        public string type { get; set; }
        public string exchDisp { get; set; }
        public string typeDisp { get; set; }
    }
    
    public class ResultSet
    {
        public string Query { get; set; }
        public List<Result> Result { get; set; }
    }
    
    public class RootObject
    {
        public ResultSet ResultSet { get; set; }
    }
