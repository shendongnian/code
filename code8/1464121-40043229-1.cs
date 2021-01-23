    public MainWindow()
    {
        InitializeComponent();
        List<MyViewModel1> Items = new List<MyViewModel1>();
        Items.Add(new MyViewModel1() { Name = "Leonardo" });
        Items.Add(new MyViewModel1() { Name = "Michael Angelo" });
        Items.Add(new MyViewModel1() { Name = "Master Splinter" });
        DataContext = Items;
    
    }
