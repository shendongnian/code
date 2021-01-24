    public class Dimensions
    {
        public string length { get; set; }
        public string width { get; set; }
        public string height { get; set; }
    }
    
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
    }
    
    public class Image
    {
        public int id { get; set; }
        public DateTime date_created { get; set; }
        public DateTime date_created_gmt { get; set; }
        public DateTime date_modified { get; set; }
        public DateTime date_modified_gmt { get; set; }
        public string src { get; set; }
        public string name { get; set; }
        public string alt { get; set; }
        public int position { get; set; }
    }
    
    public class MetaData
    {
        public int id { get; set; }
        public string key { get; set; }
        public object value { get; set; }
    }
    
    public class Self
    {
        public string href { get; set; }
    }
    
    public class Collection
    {
        public string href { get; set; }
    }
    
    public class Links
    {
        public List<Self> self { get; set; }
        public List<Collection> collection { get; set; }
    }
    
    ...
