    public MainWindow()
    {
        InitializeComponent();
    
    
        List<MyViewModel1> Items = new List<MyViewModel1>();
        Items.Add(new MyViewModel1() { Name = "Leonardo" , AvailableNames = new List<string>() { "Leonardo", "Michael Angelo" } });
        Items.Add(new MyViewModel1() { Name = "Michael Angelo", AvailableNames = new List<string>() {  "Michael Angelo"} }); // can't make a leonardo out of this item
        Items.Add(new MyViewModel1() { Name = "Master Splinter", AvailableNames = new List<string>() { "Master Splinter", "Jon Skeet" } }); // master stays master PERIOD ..... or become Jon Skeet
        DataContext = Items;
    
    }
