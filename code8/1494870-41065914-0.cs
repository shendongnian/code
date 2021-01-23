    public class YogaClass
    {
        [Key]
        public int YogaClassID { get; set; }
        public virtual List<YogaClassSubscription> Subscriptions { get; set; }
    }
    
    public class WorkShop
    {
        [Key]
        public int WorkShopID { get; set; }
        public virtual List<WorkShopSubscription> Subscriptions { get; set; }
    }
