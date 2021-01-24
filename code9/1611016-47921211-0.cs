    public class CheckStatusModel
    {
        public int OBJID { get; set; }
        public string SUPID { get; set; }
        public string STATUSPTC { get; set; }  
        public int DATEACTIVESUP { get; set; }
    }
    
      public class CheckStatus
    {
        public List<CheckStatusModel> Data { get; set; } // data is an array so this needs to be some kind of collection
        public string StatusCode { get; set; }
    }
