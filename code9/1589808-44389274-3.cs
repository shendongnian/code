    private readonly object _lock = new object();
    public MainWindow()
    {
        InitializeComponent();
        _Shows = new ObservableCollection<Show>();
        BindingOperations.EnableCollectionSynchronization(_Shows, _lock);
        this.DataContext = Workspace.This;
        //Awaits the list of shows
        SetUpData();
    }
