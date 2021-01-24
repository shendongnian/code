    public ObservableCollection<String> StringsList { get; set; } 
 
        // Constructor 
        public MainPage() 
        { 
            InitializeComponent(); 
 
            StringsList = new ObservableCollection<string> { "First Text Item", "Second Text Item", "Third Text Item" }; 
 
            DataContext = StringsList; 
        } 
 
        private void Add_Click(object sender, RoutedEventArgs e) 
        { 
            StringsList.Add(textBox.Text); 
        } 
