     public class AuthenticationService
     {
        IUserRepository _userRepo;
        
        public AuthenticationService()
        {
          _userRepo = new UserRepository();
        }
        
        public User GetUser(string username, string password)
        {
           return _userRepo.FindByCredentials(username, password);
        }
       public User GetUserByUserName(string username)
        {
           return _userRepo.FindByUserName(username);
        }
     }
