    public class  User
    {
       public int id{get;set;}
       public virtual Subscription subscription{get;set;}
    }
    public class Subscription
    {
       public int id{get;set;}
       public bool status{get;set;}
       public int UserId{get;set;}
    }
