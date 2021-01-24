    public class LoginViewModel : PropertyChangedBase {
    
        string username;
        public string Username {
            get { return username; }
            set { 
                username = value;
                NotifyOfPropertyChange(() => Username);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }
        
        string password;
        public string Password {
            get { return password; }
            set { 
                password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }
        
        public bool CanLogin() {
            return !String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Password);
        }
        
        public void Login() {
            MessageBox.show(Password + " " + Username)
        }
    }
