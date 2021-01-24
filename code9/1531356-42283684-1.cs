    public class Rootobject {
       public string[] _class { get; set; }
       public Properties properties { get; set; }
       public Entity[] entities { get; set; }
       public Link[] links { get; set; }
    }
    
    public class Properties {
       public int defaultPageSize { get; set; }
       public object skip { get; set; }
       public int top { get; set; }
       public int totalRows { get; set; }
    }
    
    public class Entity {
       public string[] _class { get; set; }
       public object[] rel { get; set; }
       public Properties1 properties { get; set; }
    }
    
    public class Properties1 {
       public string Supplier { get; set; }
       public string Currency { get; set; }
       public string ProductCode { get; set; }
       public int price { get; set; }
    }
    
    public class Link {
       public string[] rel { get; set; }
       public string href { get; set; }
       public string method { get; set; }
       public object title { get; set; }
       public object type { get; set; }
    }
