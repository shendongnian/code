    class User
    {
        public int Id {get; set;}
        // a user has zero or more bank accountTypes
        public virtual ICollection<BankAccountType> BankAccountTypes {get; set;}
        ...
    }
    enum AcctType
    {
        single,
        joint,
    };
    class BankAccountType
    {
        public int Id {get; set;}
        // every bank account type belongs to one user via foreign key UserId:
        public int UserId {get; set;}
        public virtual User User {get; set;}
        public AcctType AccType {get; set;}
        public int AcctNo {get; set;}
    }
