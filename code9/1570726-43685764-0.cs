    public class Data
    {
        public Dictionary<string, string> Dev { get; set; }
        public Dictionary<string, string> Test{ get; set; }
    
        public Data ()
        {
            Dev = new Dictionary<string, string>();
            Test = new Dictionary<string, string>();
        }
    }
