    public class Account
    {
        public int AccountId { get; set; }
        public virtual ICollection<Addresses> Addresses { get; set; }
    }
 ___   
    public class Address
    {
        public int AddressId { get; set; }
        public int AccountId { get; set; }
        public virtual Accounts Account { get; set; }
    }
