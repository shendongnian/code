    public class LiquiditySource
    {
        public int ID { get; set; }
        public object ParentID { get; set; }
        public string Name { get; set; }
        public object SequenceNo { get; set; }
        public string Caption { get; set; }
        public string ConnectivityInfo { get; set; }
    }
    
    public class LookupData
    {
        public List<LiquiditySource> LiquiditySources { get; set; }
    }
    
    public class SampleClass
    {
        public string AccessToken { get; set; }
        public int LoggedInUserID { get; set; }
        public LookupData LookupData { get; set; }
    }
    string json = "your json string";
    SampleClass obj = JsonConvert.DeserializeObject<SampleClass>(json);
