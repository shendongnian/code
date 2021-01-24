    public src.UserList UserList { get; } = new src.UserList();
    public MainWindow()
    {
        InitializeComponent();
        DataConnection.CreateAndOpenDB();
        // add elements to UserList here
        DataContext = this;
    }
