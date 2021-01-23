    public ObservableCollection<obj> myData { get; } = new ObservableCollection<obj>();
    public MainWindow()
    {
        InitializeComponent();
        InitializeMyData();
        DataContext = this;
    }
