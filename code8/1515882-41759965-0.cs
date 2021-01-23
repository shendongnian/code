    public class User
    {
      public int UserID{get;set}
      public string Name...
      public List<UserBank> MyBanks{ ... fetch by this.UserID ... }
    }
    public class Bank
    {
      public int BankID{get;set}
      public string Name{get;set;}
      public List<UserBank> MyUsers{... fetch by this.BankID ... }
    }
    
    public class UserBank
    {
      public int UserBankID{get;set}
      public User{get;set;}
      public Bank{get;set;} 
    }
