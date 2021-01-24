    class User
    {
        ...
        // every user has zero or one Account:
        public virtual Account Account {get; set;}
    }
    class Account
    {
        ...
        // every Account belongs to zero or one User
        public virtual User User  {get; set;}
    }
