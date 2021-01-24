    public class User
        {
            public Guid UserId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public virtual ICollection<Transaction> TransactionHistory { get; set; }
        }
        
        public class Transaction
        {    
            public int TransactionId { get; set; }
            public string TransactionName { get; set; }
            public DateTime CreatedDateTime { get; set; }
        }
