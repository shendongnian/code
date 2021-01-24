    public abstract class AccountManager
    {
        //public void DeleteAccount(string userId)
        protected void DeleteAccount(string userId)
        {
    
        }
    
        ...
    }
    
    public class Administrator : AccountManager
    {
      public void DeleteAccount(string userId) { base.DeleteAccount(); }
    }
    
    public class Moderator : AccountManager
    {
    
    }
