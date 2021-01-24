    public MainPage()
    {
        this.InitializeComponent();
        // Initialize the property
        this.Items = new ObservableCollection<string>();
        // Use self as datacontext (but would normally use a separate viewmodel)
        this.DataContext = this;
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        // add a new item to the UI
        this.Items.Add(DateTime.Now.ToString());
    }
    // The "collection" that is shown in the UI
    public ObservableCollection<string> Items { get; set; }
