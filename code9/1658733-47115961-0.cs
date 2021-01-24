    public class RootObject
    {
        public Dictionary<string, Dictionary<string, DateValue>> response { get; set; }
    }
    public class DateValue
    {
        public int mean { get; set; }
        public int min { get; set; }
        public int max { get; set; }
    }
