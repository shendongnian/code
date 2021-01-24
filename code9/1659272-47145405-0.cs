    public class LoginViewModel {
        public string Email {
            get;
            set;
        }
        public string Password {
            get;
            set;
        }
        public ICommand LoginCommand {
            get {
                return new Command(async() => {
                    ApiServices apiServices = new ApiServices();
                    await Task.Run(() => {
                        apiServices.LoginUserAsync(Email, Password);
                    });
            }
        }
    }
