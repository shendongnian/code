    public abstract class Human : BaseEntity
    {
        public ICollection<Address> Addresses { get; set; }
    }
    public class People : Human
    {
    }
    public class Merchant : Human
    {
    }
