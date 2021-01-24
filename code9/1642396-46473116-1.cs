    public MainPage()
    {
        this.InitializeComponent();
    
        Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += App_BackRequested;
        this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
    
        TextBoxRicerca.Visibility = Visibility.Collapsed;
        Mappe.Loaded += Mappe_Loaded;
    
        Regione.RegNome = "";
    
        **Loaded += Loading;**
    
        //this.Frame.Navigate(typeof(RegionPage));                
    }
