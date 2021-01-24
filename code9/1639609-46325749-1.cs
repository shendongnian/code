    public class ObjType
    {
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
        public string Value4 { get; set; }
    }
    
    public class SubscriptionsType
    {
        public ObjType Obj1 { get; set; }
        public ObjType Obj2 { get; set; }
        public ObjType Obj3 { get; set; }
    }
    
    public class RootObject
    {
        public SubscriptionsType SubscriptionsType1 { get; set; }
        public SubscriptionsType SubscriptionsType2 { get; set; }
    }
