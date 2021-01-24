      public class Bnd
    {
        public string _path { get; set; }
        public List<string> _parts { get; set; }
        public string _key { get; set; }
    }
    
    public class __invalid_type__0
    {
        public Bnd _bnd { get; set; }
    }
    
    public class Bnd2
    {
        public string _path { get; set; }
        public string _parts { get; set; }
        public string _key { get; set; }
    }
    
    public class __invalid_type__1
    {
        public Bnd2 _bnd { get; set; }
    }
    
    public class Handler
    {
    }
    
    public class CollectionChanged
    {
        public List<Handler> _handlers { get; set; }
    }
    
    public class RootObject
    {
        public __invalid_type__0 __invalid_name__0 { get; set; }
        public __invalid_type__1 __invalid_name__1 { get; set; }
        public int length { get; set; }
        public int _updating { get; set; }
        public CollectionChanged collectionChanged { get; set; }
    }
