    public abstract class TrackedEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
    public class SomeOtherClass : TrackedEntity
    {
         // Class specific properties here
    }
