    public class MyReturnObject {
        public List<MyDataObject> Data { get; set; }
        public Metadata Meta { get; set; }
    }
    
    public class Metadata {
        public int FirstRecord { get; set; }
        public int LastRecord { get; set; }
        public int Page { get; set; }
        public object Sync { get; set; }
    }
