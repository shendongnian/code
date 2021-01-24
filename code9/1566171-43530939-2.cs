    public class Result
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Id { get; set; }
    }
    
    public class ResponseClass
    {
        public string ReportName { get; set; }
        public List<Result> Results { get; set; }
    }
