    public class UserAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Employee Employee {get;set;}
        public Customer Customer {get;set;}
    }
    
    public class Employee 
    {
        public User User {get;set;}
    }
    
    public class Customer
    {
        public User User {get;set;}
    }
