    public VotePage()
    {
        this.InitializeComponent();
        this.Loaded += OnLoaded;
    }
    public async void OnLoaded(object sender, RoutedEventArgs e)
    {
        DataContext = await GamesList.Create("database name...");
    }
