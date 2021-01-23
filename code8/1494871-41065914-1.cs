    public class WorkshopSubscription : Subscription
    {
        public virtual Workshop Workshop { get; set; }
    }
    
    public class YogaClassSubscription : Subscription
    {
        public virtual YogaClass YogaClass { get; set; }
    }
