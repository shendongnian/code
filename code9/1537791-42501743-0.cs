    public class MainViewModel : MvxViewModel
    {
        private string _login;
        private string _password;
    
        public string Login
        {
            get { return _login; }
            set { _login = value; RaisePropertyChanged(() => Login); }
        }
    
        public string Password
        {
            get { return _password; }
            set { _password = value; RaisePropertyChanged(() => Password); }
        }
    
        public ICommand LoginAction
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<HomeViewModel>(new {Login,Password}));
            }
        }
    }
