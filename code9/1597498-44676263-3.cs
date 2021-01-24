    public class Element
    {
        public string url { get; set; }
        public string name { get; set; }
    }
    
    public class Category1
    {
        public List<Element> Elements { get; set; }
    }
    
    public class Short
    {
        public string url { get; set; }
        public string name { get; set; }
    }
    
    public class Medium
    {
        public string url { get; set; }
        public string name { get; set; }
    }
    
    public class Long
    {
        public string url { get; set; }
        public string name { get; set; }
    }
    
    public class Category2
    {
        public Short @short { get; set; }
        public Medium medium { get; set; }
        public Long @long { get; set; }
    }
    
    public class Packs
    {
        public Category1 category1 { get; set; }
        public Category2 category2 { get; set; }
    }
    
    public class PacksModel
    {
        public Packs packs { get; set; }
    }
