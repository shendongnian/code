       public class Collector
       {
         public Collector() 
         {
            set MyList = new Collection<TestModel>();
         }
        public int CollectorID { get; set; }
        public string CollectorString { get; set; }
        public ICollection<TestModel> MyList { get; set; }
       }
