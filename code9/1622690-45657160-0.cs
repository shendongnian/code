    public partial class FirstPage : ContentPage, INavigatedAware
    {
        INavigationService _navigationService;
        bool myCondition = true;
        public FirstPage(INavigationService navigationService)
        {
            _navigationService = navigationService;
            InitializeComponent();
        }
        void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }
        void OnNavigatedTo(NavigationParameters parameters)
        {
            if(myCondition == true)
            {
               _navigationService.NavigateAsync("SecondPage");
            }
        }
     }
