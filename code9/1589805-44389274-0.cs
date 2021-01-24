    public MainWindow()
    {
        InitializeComponent();
        _Shows = new ObservableCollection<TrioShow>();
        this.DataContext = Workspace.This;
        //Awaits the list of shows
        SetUpData();
    }
