    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty( ref _message, value ); }
        }
        public void OnNavigatedTo( NavigationParameters parameters )
        {
            Message = parameters[ "message" ].ToString();
        }
    }
