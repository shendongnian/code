        public class AppViewModel : ViewModelBase
    {
        ...
        public AppViewModel()
        {
            var loginViewModel = new LoginViewModel();
            loginViewModel.UserLoginSuccessfullyEvent += new UserLoginSuccessfullyHandler(myUserLoginSuccessfullyHandler);
            CurrentView = loginViewModel;
        }
        
        private void myUserLoginSuccessfullyHandler()
        {
            CurrentView = new SignUpViewModel();
        }
        
        ...
    }
