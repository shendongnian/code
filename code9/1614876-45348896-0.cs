    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new TestViewModel();
        }
    }
    public class TestViewModel : ViewModelBase
    {
        private string _selectedItem;
        public RelayCommand Command { get; }
        public ObservableCollection<string> ItemsSource { get; }
        public string SelectedItem
        {
            get { return _selectedItem; }
            set { Set(ref _selectedItem, value); }
        }
        public TestViewModel()
        {
            Command = new RelayCommand(() => SelectedItem = null);
            ItemsSource = new ObservableCollection<string> { "index 0", "index 1", "index 2", "index 3" };
        }
    }
