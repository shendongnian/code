       public class User
        {
            [Key]
            public int UserId { get; set; }
            public int? HomeAddressId { get; set; }
        
            public virtual ICollection<Address> Addresses { get; set; }
            public Address HomeAddress { 
               get {
                    if(Addresses != null)
                       return Addresses.FirstOrDefault(p=> p.AddressType.Home);
                    return null;
               }
            }
        }
        public enum AddressType
        {
            Unknown,
            Home,
            Office
        }
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public int UserId { get; set; }
        public string AddressLine1 { get; set; } 
        public AddressType AddressType {get; set; }
    
        // other properties
        public virtual User User { get; set; }
    }
