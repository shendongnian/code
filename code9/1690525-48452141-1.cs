    public class SplitViewPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
    		
        public SplitViewPageViewModel(INavigationService navService)
        {
            _navigationService = navService;
            // construction removed here
        }
    
        private ICommand _OtherPageCommand;
        public ICommand OtherPageCommand
        {
            get
            {
                return _OtherPageCommand ??
                    new RelayCommand(() =>
                    {
    	                _PanelPage = null; // <-- Added this
                        _navigationService.Navigate(typeof(OtherPage));
                    });
            }
        }
    
        private ICommand _HomePageCommand;
        public ICommand HomePageCommand
        {
            get
            {
                return _HomePageCommand ??
                    new RelayCommand(() =>
                    {
    	                _PanelPage = null; // <-- Added this
                        _navigationService.Navigate(typeof(HomePage));
                    });
            }
        }
    
        private Page _PanelPage;
        public Page PanelPage
        {
            get
            {
                // build page on demand
                return _PanelPage ?? (_PanelPage = new Views.PanelPage());
            }
            set
            {
                _PanelPage = value;
                RaisePropertyChanged("PanelPage");
            }
        }
    }
