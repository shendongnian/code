    public class Collector {
        public Collector() {
            MyList = new List<TestModel>(); 
        }
        public int CollectorID { get; set; }
        public string CollectorString { get; set; }
        public IList<TestModel> MyList { get; set; }
    }
