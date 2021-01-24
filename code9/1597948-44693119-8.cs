    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = new ViewModel();
            vm.Items.Add(new DataItem { Text = "Item 1" });
            vm.Items.Add(new DataItem { Text = "Item 2" });
            vm.Items.Add(new DataItem { Text = "Item 3" });
            vm.Items.Add(new DataItem { Text = "Item 4" });
            DataContext = vm;
        }
    }
    public class DataItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Text)));
            }
        }
    }
    public class ViewModel
    {
        public ObservableCollection<DataItem> Items { get; }
            = new ObservableCollection<DataItem>();
    }
