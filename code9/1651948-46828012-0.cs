    public abstract class AccountManager
    {
        public void DeleteAccount(string userId)
        {
        }
    
        public void AccountDetail(string userId)
        {
    
        }
    }
    
    public class Administrator : AccountManager
    {
    
    }
    
    public class Moderator : AccountManager
    {
        public void DeleteAccount(string userId)
        {
            throw new Exception("You have not a right permission");
        }
    }
