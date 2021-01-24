    public ObservableCollection<Person> Persons {get; set;}
    
    public MainWindow()
        {
            InitializeComponent();
    
            var lines = File.ReadAllLines(filepath);
            Persons = new ObservableCollection<Person>();
