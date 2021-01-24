    public class RootObject
    {
        public Task task { get; set; }
    }
    
    public class Task
    {
        public int id { get; set; }
        public string status { get; set; }
        public object error { get; set; }
        public DateTime date_created { get; set; }
        public DateTime date_updated { get; set; }
        public Data data { get; set; }
    }
    
    public class Data
    {
        public int width { get; set; }
        public Dictionary<string, List<Item>> boxes { get; set; }
        public int height { get; set; }
    }
    
    public class Item
    {
        public double xmin { get; set; }
        public double ymin { get; set; }
        public double ymax { get; set; }
        public double xmax { get; set; }
        public double proba { get; set; }
    }
