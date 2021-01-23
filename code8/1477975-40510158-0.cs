    public class MyRoot
        {
            public DateTime LastUpdated { get; set; }
            public List<MyRates> Rates { get; set; }
        }
    public class MyRates
    {
        public string Type { get; set; }
        public string Rate { get; set;}
        public string Program { get; set; }
    }
