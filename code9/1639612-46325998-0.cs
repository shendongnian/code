    public class RootObject : Dictionary<string, Subscriptions> { }
    public class Subscriptions : Dictionary<string, SubscriptionObj> { }
    public class SubscriptionObj {
        public Int64 Value1 {get;set;}
        public Int64 Value2 {get;set;}
        public Int64 Value3 {get;set;}
        public Boolean Value4 {get;set;}
    }
