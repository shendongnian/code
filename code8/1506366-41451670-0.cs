    public class Rootobject
    {
        public Cuisine[] cuisines { get; set; }
    }
    
    public class Cuisine
    {
        public Cuisine1 cuisine { get; set; }
    }
    
    public class Cuisine1
    {
        public int cuisine_id { get; set; }
        public string cuisine_name { get; set; }
    }
