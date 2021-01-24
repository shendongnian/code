    public class Address
    {
        public Guid Id { get; set; }
    
        public virtual ICollection<AddressMessageLink> AddressMessageLink { get; set; }
    }
    public class Message
    {
        public Guid Id { get; set; }
    
        public virtual ICollection<AddressMessageLink> AddressMessageLink { get; set; }
    }
