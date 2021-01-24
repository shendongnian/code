    public class AddressMessageLink
    {
        public int LinkType { get; set; }
        public Guid AddressId { get; set; }
        public Guid MessageId { get; set; }
    
        public virtual Address Address { get; set; }
        public virtual Message Message { get; set; }
    } 
