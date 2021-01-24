    public sealed partial class MyShell : Page
    {
        public static MyShell Instance { get; set; }
    
        public static HamburgerMenu HamburgerMenu => Instance.MyHamburgerMenu;
    
        Services.SettingsServices.SettingsService _settings;
        public MyShell()
        {
            Instance = this;
            this.InitializeComponent();
            _settings = Services.SettingsServices.SettingsService.Instance;
            var service = BootStrapper.Current.NavigationServiceFactory(BootStrapper.BackButton.Attach, BootStrapper.ExistingContent.Exclude);          
            SetNavigationService(service);
    
        }  
        public void SetNavigationService(INavigationService navigationService)
        {
            MyHamburgerMenu.NavigationService = navigationService;
            HamburgerMenu.RefreshStyles(_settings.AppTheme, true);
            HamburgerMenu.IsFullScreen = _settings.IsFullScreen;
            HamburgerMenu.HamburgerButtonVisibility = _settings.ShowHamburgerButton ? Visibility.Visible : Visibility.Collapsed;
        }
    }
