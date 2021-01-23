    public class Alpha
    {
        public int one { get; set; }
        public string two { get; set; }
    }
    
    public class Sample1
    {
        public string one { get; set; }
        public string two { get; set; }
        public int three { get; set; }
    }
    
    public class Location
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
    
    public class Photo
    {
        public string caption { get; set; }
        public List<Location> location { get; set; }
    }
    
    public class Sample2
    {
        public int id { get; set; }
        public string content { get; set; }
        public List<Photo> photos { get; set; }
    }
    
    public class Bravo
    {
        public Sample1 sample1 { get; set; }
        public List<Sample2> sample2 { get; set; }
    }
    
    public class RootObject
    {
        public Alpha alpha { get; set; }
        public Bravo bravo { get; set; }
    }
