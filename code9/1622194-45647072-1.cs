    public class DataObject
    {
        public string token { get; set; }
    }
    
    public class MyResponseObject
    {
        public string error_code { get; set; }
        public string error_desc { get; set; }
        public DataObject data { get; set; }
    }
