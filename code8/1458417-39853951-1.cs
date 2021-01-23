    public class GetItemsListResult
    {
        public string code { get; set; }
        public int clsID { get; set; }
        public int type { get; set; }
        public int status { get; set; }
        public double free { get; set; }
        public double total { get; set; }
        public int perc { get; set; }
        public string descr { get; set; }
        public int dt { get; set; }
        public int tm { get; set; }
        public int full { get; set; }
    }
    
    public class RootObject
    {
        public List<GetItemsListResult> GetItemsListResult { get; set; }
    }
