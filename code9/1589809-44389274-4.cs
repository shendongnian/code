    public MainWindow()
    {
        InitializeComponent();
        _Shows = new ObservableCollection<Show>();
        this.DataContext = Workspace.This;
        //Awaits the list of shows
        SetUpData();
    }
