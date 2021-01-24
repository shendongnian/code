    class Account
    {
        public string Email {get; set;}
        public string Password {get; set;} // by the way: very unsave, prone to be hacked
        ...
    }
    class User
    {
         public string Name {get; set;}
         public Account Account {get; set;}
         ...
    }
