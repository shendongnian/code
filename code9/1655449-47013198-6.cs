    public MainWindow() {
        InitializeComponent();
        this.Clients = InitializeListView();
        this.DataContext = this;        
    }
    
    public ClientListViewModel Clients { get; set; }
    
    private ClientListViewModel InitializeListView() {
        var model = new ClientListViewModel();
        model.Read();    
        return model;
    }
