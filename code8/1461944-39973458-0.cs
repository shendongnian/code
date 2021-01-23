    public Page1()
    {
        this.InitializeComponent();
        NavigationCacheMode = NavigationCacheMode.Enabled; // or NavigationCacheMode.Required if you want to ignore caching limits.
        Books = BookManager.GetBooks();
        ts1 = Books.Where(p => p.bogNa == "Robert").ToList();
    }
