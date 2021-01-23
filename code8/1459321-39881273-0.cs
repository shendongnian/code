    public class Inneritem
    {
        public String itemid { get; set; }
    }
    public class Outeritem
    {
        public List<Inneritem> inneritems { get; set; }
    }
    
    public class RootValue
    {
        public List<Outeritem> outeritems { get; set; }
    }
