    public class ResultDocument
    {
        public IEnumerable<ResultObject> _hits { get; set; }
    
    }
    public class ResultObject 
    {
        public emp source { set;get; }
    }
    
    var objemp = JsonConvert.DeserializeObject<ResultDocument>(testdata);
