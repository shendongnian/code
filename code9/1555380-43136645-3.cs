    public class RootObject
    {
        public List<Count> count { get; set; }
    }
    public class Count
    {
        public List<Place> place { get; set; }
    }
    public class Place
    {
        public int first { get; set; }
        public int second { get; set; }
        public int third { get; set; }
    }
