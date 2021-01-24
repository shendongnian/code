    public class RootObject {
            public Subscriptions SubscriptionCollection { get; set; }
    }
    
    
    public class Subscriptions {
        IEnumerable<SubscriptionObj> objs;
    }
    
    public class SubscriptionObj
    {
        public Int64 Value1 {get;set;}
        public Int64 Value2 {get;set;}
        public Int64 Value3 {get;set;}
        public Boolean Value4 {get;set;}
    }
