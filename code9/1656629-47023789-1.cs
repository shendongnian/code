    public class MyClass
    {
        public string collectionName { get; set; }
        public int recordCount { get; set; }
    
        public int skippedRecordCount { get; set; }
    
        public ResultField[] resultFieldList { get; set; }
    }
    
    public class ResultField
    {
        public string fieldName { get; set; }
    
        public string analyticsDataType { get; set; }
    
        public object[] values { get; set; }
    }
