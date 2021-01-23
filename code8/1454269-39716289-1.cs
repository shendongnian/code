    public partial class MainWindow : Window , INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly List<string> _namesList = new List<string>();
        public string SelectedName
        {
            get { return _namesList[1]; }            
        }
        public MainWindow()
        {
            InitializeComponent();
            _namesList.Add("ABC");
            _namesList.Add("DEF");
            _namesList.Add("GHI");
            DataContext = this;
        }
        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            var str = _namesList[0];
            _namesList[0] = _namesList[1];
            _namesList[1] = str;
            NotifyPropertyChanged(nameof(SelectedName));
            IsEnabled = false;
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            var str = _namesList[2];
            _namesList[2] = _namesList[1];
            _namesList[1] = str;
            NotifyPropertyChanged(nameof(SelectedName));
            IsEnabled = false;
        }
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
