    public MyPage()
    {
        InitializeComponent();
    
        Loaded += (s, e) => ViewModel = new MyPageViewModel();
    }
