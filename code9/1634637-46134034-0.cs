    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _testProperty;
        public string TestProperty
        {
            get { return _testProperty; }
            set
            {
                _testProperty = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TestProperty"));
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TestProperty = "Test";
        }
        public MainWindow()
        {
            InitializeComponent();
        }
    }
