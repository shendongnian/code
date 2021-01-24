    // This class holds login/password: so it's it that responsible for validation
    public class MyLogin() {
      public MyLogin(string login, string password) {
        if (null == login)
          throw new ArgumentNullException("login"); 
        else if (null == password)
          throw new ArgumentNullException("password"); 
    
        Login = login;
        Password = password; 
      }
    
      // Property with a readble name (what's X?)
      public string Login {
        get;
        private set;
      }
    
      // Property with a readble name (what's Y?)
      public string Password {
        get;
        private set;
      }
    
      public bool IsValid {
        get {
          return !string.IsNullOrEmpty(Login) &&
                 !string.IsNullOrEmpty(Password); 
        }
      }
    }
    
