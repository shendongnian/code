    class Customer {
        public int CustomerId {get;set;} // PK that was already there
        // new navigation property
        public virtual ICollection<Account> Accounts { get; set; }
    }
    
    class Account {
        public int AccountId {get;set;} 
       
        // new FK
        public int CustomerId { get;set; }
        // new navigation property
        public virtual Customer Customer {get;set;} 
    }
