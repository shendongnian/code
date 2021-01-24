    public App()
    {
        InitializeComponent();
        MainPage = new MasterDetailPage()
        {
            Master=new MainPage(),
            Detail=new NavigationPage(new Detail())
            {
                BarBackgroundColor=Color.Transparent,
                BackgroundColor=Color.Transparent
            },
            BackgroundImage="tianyuan.jpg"
        };
    }
