    public class Class1
    {
        public string group { get; set; }
        public string tracker { get; set; }
        public string measureTime { get; set; }
        public int minAgo { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public List<History> history { get; set; }
        public List<History> GetListHistories(){
          return history;
        }
    }
    public class History
    {
        public float lat { get; set; }
        public float lon { get; set; }
        public int minAgo { get; set; }
    }
