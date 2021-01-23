    public class LoginViewModel : ViewModelBase
    {
        ...
        public delegate void UserLoginSuccessfullyHandler();
        public event UserLoginSuccessfullyHandler UserLoginSuccessfullyEvent;
        private void SendLoginRequest()
        {
          LoginResponse response = UserServiceProxy.Login(new LoginRequest { UserName = UserName, Password = Password });
            ConsoleLog.Document += $"{response.IsSuccess} {response.Message}";
          if(response.IsSuccess == true)
            {
                AuthenticatedUser.Authentication = response.Authentication;
                JoinServiceResponse responseFromChatService = ChatServiceProxy.JoinService(new JoinServiceRequest());
                ConsoleLog.Document += responseFromChatService.Message;
                // This is where you inform the AppViewModel to change his CurrentView
                if (UserLoginSuccessfullyEvent!= null)
                    UserLoginSuccessfullyEvent();
            }
        }
        ...
    }
