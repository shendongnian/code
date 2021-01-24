    private ViewModel myViewModel;
    
    public MainPage()
    {
        this.InitializeComponent();
        myViewModel = new ViewModel();
        MyGridView.DataContext = myViewModel;
    }
