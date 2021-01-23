    public class Authentication : IAuthenticationService {
        private readonly GameContext db;
    
        public Authentication(GameContext context) {
            db = context;
        }
    
        public LoginResponseModel Login(LoginModel user) {
            //query user
            var detectedUser = db.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == HelperClass.Md5(user.Password));
            //...other code that creates and returns an instance of LoginResponseModel
        }
    }
