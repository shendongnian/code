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
