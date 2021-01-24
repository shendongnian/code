    public class LoginViewModel : ViewModelBase
    {
        public ICommand LoginCommand { get; set; }
        #region Properties
        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        #endregion
        public LoginViewModel()
        {
            LoginCommand = new Command(Login);
        }
        public string CleanResponse(string reason)
        {
            var str = reason;
            var charsToRemove = new string[] { "[", "]", "{", "}", "\"" };
            foreach (var c in charsToRemove)
            {
                str = str.Replace(c, string.Empty);
            }
            return str;
        }
        private async void Login()
        {
           //Validations here
            if (Email == "")
            {
                await DisplayAlert("Validation Error", "You must enter an Email address", "OK");
                return;
            }
            else if (Password == "")
            {
                await DisplayAlert("Validation Error", "You must enter a Password", "OK");
                return;
            }
            //We are good to go
            else
            {
                IsBusy = true;
                string APIServer = Application.Current.Properties["APIServer"].ToString();
                var client = new RestClient(APIServer);
                var request = new RestRequest("api/account/sign-in", Method.POST);
                request.AddHeader("Content-type", "application/json");
                request.AddJsonBody(new
                                        {
                                            email = Email,
                                            password = Password                                        }
                                    );
                var response = client.Execute(request) as RestResponse;
                IsBusy = false;
                //Valid response
                if (response.StatusCode.ToString() == "OK")
                {
                    var tokenobject = JsonConvert.DeserializeObject<TokenModel>(response.Content);
                    Application.Current.Properties["Token"] = tokenobject.Access_token;
                    string token = Application.Current.Properties["Token"].ToString();
                    App.Current.MainPage = new NavigationPage(new MainPage());
                }
                //Error response
                else
                {
                    var statuscode = response.StatusCode.ToString();
                    var content = response.Content;
                    var exception = response.ErrorException;
                    var error = response.ErrorMessage;
                    var statusdesc = response.StatusDescription;
                    await DisplayAlert("Login Failed", "Your login has failed. Please check your details and try again.", "OK");
                }
            }
        }
    }
