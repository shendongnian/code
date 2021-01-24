    public class Devandreason
    {
        public int device { get; set; }
        public int reason { get; set; }
    }
    
    public class RootObject
    {
        public string action { get; set; }
        public string devices { get; set; }
        public List<Devandreason> devandreason { get; set; }
    }
