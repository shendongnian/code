    public string MyName { get; set; }
    public MainWindow()
    {
        MyName = "Dummy";
        InitializeComponent();
        DataContext = this;
    }
