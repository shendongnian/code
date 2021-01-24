    public MainWindow()
    {
        InitializeComponent();
        ViewModel = new Model();
    }
    public Model ViewModel { 
        get { return DataContext as Model; }
        set { DataContext = value; }
    }
