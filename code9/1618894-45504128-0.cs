    private ICommand navigatePackagesCommand;
    
            public ICommand NavigatePackagesCommand
            {
                get { return navigatePackagesCommand; }
            }
    
    public YourPageViewModel(INavigationService navigationService)
            {
                _navigationService = navigationService;
     //...
    }
