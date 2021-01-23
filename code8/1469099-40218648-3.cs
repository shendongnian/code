    public ObservableCollection<Thickness> MyCollection { get; set; }
    public MainWindow()
    {
    	InitializeComponent();
    
    	MyCollection = new ObservableCollection<Thickness>();
    	MyCollection.Add(new Thickness(5, 5, 5, 5));
    	MyCollection.Add(new Thickness(10, 10, 10, 10));
    	// ...
    	DataContext = this;
    }
