    public class Rootobject
    {
        public string areaId { get; set; }
        public string cat { get; set; }
        public string subcat { get; set; }
        public string location { get; set; }
        public string sublocation { get; set; }
        public string briefDescription { get; set; }
        public string detailedDescription { get; set; }
        public Images images { get; set; }
    }
    
    public class Images
    {
        public string image1 { get; set; }
        public string image2 { get; set; }
    }
