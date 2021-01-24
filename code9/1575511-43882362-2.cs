    public App()
    {
        InitializeComponent();
    
        MainPage = new NavigationPage(new MainPage())
        {
            BackgroundColor = Color.Red
        };
    }
