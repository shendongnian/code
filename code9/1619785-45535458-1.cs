    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
        Provinces.Add(new Province() { Name = "A", Cities = new ObservableCollection<string>() { "City A1", "City A2" } });
        Provinces.Add(new Province() { Name = "B", Cities = new ObservableCollection<string>() { "City B1", "City B2" } });
    }
    public ObservableCollection<Province> Provinces { get; set; } = new ObservableCollection<Province>();
