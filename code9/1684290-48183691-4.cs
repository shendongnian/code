    class User
    {
        public int Id {get; set;}
        // every user has zero or more Accounts:
        public virtual ICollection<Account> Accounts {get; set;}
        ...
    }
    class Account
    {
        public int Id {get; set;}
        
        // every Account belongs to exactly one User, using foreign key:
        public int UserId {get; set;}
        public virtual User User {get; set;}
        ...
    }
