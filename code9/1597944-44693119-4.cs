    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = new ViewModel();
            vm.Items.Add(new DataItem("Option1", "Option2", "Option3"));
            vm.Items.Add(new DataItem("Option1", "Option2"));
            vm.Items.Add(new DataItem("Option2", "Option1", "Option3"));
            vm.Items.Add(new DataItem("Option1", "Option2"));
            DataContext = vm;
        }
    }
    public class DataItem : INotifyPropertyChanged
    {
        public DataItem(params string[] options)
        {
            Options = options;
            SelectedOption = options.FirstOrDefault();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public IEnumerable<string> Options { get; set; }
        private string selectedOption;
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
