    public class LogSearch
    {
        public Option Option { get; set; }
        public Result Result { get; set; }
    
        public LogSearch()
        {
            Option = new Option();
            Result = new Result();
        }
    }
    
    [Serializable]
    public class Option
    {
        public string Manufacturer { get; set; }
        public string T9 { get; set; }
        public Option()
        {
            Manufacturer = string.Empty;
            T9 = string.Empty;
        }
    }
    
    [Serializable]
    public class Result
    {
        public int Count { get; set; }
        [XmlArray]
        public List<string> Results { get; set; }
    
        public Result()
        {
            Count = 0;
            Results = new List<string>();
        }
    }
