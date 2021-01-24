    public class MyPrincipal: IPrincipal 
    {
        private MyIdentity _identity;
        private string[] _roles;
       
        public MyPrincipal(MyIdentity identity, string[] roles) 
        {
           _identity = identity;
           _roles = roles;
        }
        public bool IsInRole(string role) 
        {
          return _roles?.Length > 0 && _roles.Contains(role);
        }
      
        IIdentity IPrincipal.Identity 
        {
           get 
           {
              return _identity;
           } 
        }
         
        public MyIdentity Identity 
        {
           get { return _identity;}
        }
        // User ID you need
        public int UserId 
        {
           get 
           {
              return Identity.UserId;
           }
        }
    }
    somewhere in your code 
    @{
        int currentUserId = (User as MyPrincipal).UserId; 
    }   
    @if (currentUserId == Model.userId) 
    {
         // this will be executed personally per executing user
    }
    
 
