    public class Details
    {
        public Customer customer { get; set; }
        public Points points { get; set; }
        public Colors colors { get; set; }
    }
    public class Points
    {
        public List<Point> point { get; set; }
    }
    public class Color
    {
        public List<Color> color { get; set; }
    }
