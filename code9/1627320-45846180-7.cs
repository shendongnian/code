    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]     
        public int CustomerGroupId { get; set; }
        public virtual CustomerGroup CustomerGroup { get; set; }    
    }
