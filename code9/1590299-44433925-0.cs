    public class Person : EntityWithTypedId<PersonCompositeId>
    {
        public virtual string Key { get; set; }
    
        public virtual string TargetBookingSystemType { get; set; }
    }
