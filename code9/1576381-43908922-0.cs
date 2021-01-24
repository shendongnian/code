     private ObservableCollection<Class4> Items;
     public MainPage()
     {
         this.InitializeComponent();
         Items = new ObservableCollection<Class4>();
         verifyListView.ItemsSource = Items;
     }
