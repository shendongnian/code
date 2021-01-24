    public class Addresses
    {
        [Key]
        public int AddressId { get; set; }
        [ForeignKey("Account")]            // Not necessary
        public int AccountId { get; set; } // Necessary
    
        public virtual Accounts Account { get; set; }
    
        // Other properties...
    }
