    public class ApplicationUser
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // ...
        
        [InverseProperty("CartCustomer")]
        public virtual EquipmentHireCart CustomerCart { get; set; }
    }
    public class EquipmentHireCart
    {
        [Key, ForeignKey("CartCustomer")]
        public int CartId { get; set; }
        public int AmountInCart { get; set; }
        // ...
        public virtual ApplicationUser CartCustomer { get; set; }
    }
