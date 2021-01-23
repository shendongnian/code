    public root()
    {
        this.InitializeComponent();
    
        PassedData.passSplit = MySplitView;
    
        SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
    }
    
    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        var result = await myDatabase.checkDataBaseConnection();
        if (result)
        {
            MyFrame.Navigate(typeof(main1));
        }
    }
