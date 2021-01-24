    public class Person
    {
        [Key]
        public String Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? Birthdate { get; set; }
        public int Status { get; set; }
        public List<Account> Accounts { get; set; }
    }
    
    public class Account
    {
        [Key]
        public String Id { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public string Code { get; set; }
        public DateTime Expiry { get; set; }
    }
