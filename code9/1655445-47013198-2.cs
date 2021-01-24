    public MainWindow() {
        InitializeComponent();
        InitializeListView();
        this.DataContext = this;        
    }
    
    public ClientListViewModel Clients { get; set; }
    
    private void InitializeListView() {
        Clients = new ClientListViewModel();
        model.Read();    
    }
