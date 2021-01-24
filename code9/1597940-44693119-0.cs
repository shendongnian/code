    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = new ViewModel();
            vm.Items.Add(new DataItem());
            vm.Items.Add(new DataItem());
            vm.Items.Add(new DataItem());
            vm.Items.Add(new DataItem());
            DataContext = vm;
        }
    }
    public class DataItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public IEnumerable<string> Options { get; }
            = new string[] { "Option 1", "Option 2", "Option 3" };
        private string selectedOption = "Option 1";
        public string SelectedOption
        {
            get { return selectedOption; }
            set
            {
                selectedOption = value;
                NotifyPropertyChanged();
            }
        }
    }
    public class ViewModel 
    {
        public ObservableCollection<DataItem> Items { get; }
            = new ObservableCollection<DataItem>();
    }
