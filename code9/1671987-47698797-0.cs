    public partial class MainWindow : Window
    {
        Person _p = new Person() { Name = "Anna" };
        
        public MainWindow()
        {
            InitializeComponent();
            var coll = new ObservableCollection<Person>() { _p };
            ListCollectionView view = new ListCollectionView(coll)
            {
                Filter = p => ((Person)p).Name[0] == 'A',
                IsLiveFiltering = true,
                LiveFilteringProperties = { nameof(Person.Name) }
            };
            lb.ItemsSource = view;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _p.Name = "Elsa";
        }
    }
