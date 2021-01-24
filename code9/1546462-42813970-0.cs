    public class AuthenticationModel {
        public LoginModel Login {get;set;} 
        public RegisterModel Register {get;set;}
        public AuthenticationModel (LoginModel lModel, RegisterModel rModel) {
            Login = lModel;
            Register = rModel;
        }
    }
