    public MainWindow() {
        InitializeComponent();
        this.DataContext = this;
        InitializeListView();
    }
    
    public ClientListViewModel Clients { get; set; }
    
    private void InitializeListView() {
        Clients = new ClientListViewModel();
        model.Read();    
    }
