    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
        MyBehavior.SetView(txt, "new value...");
    }
