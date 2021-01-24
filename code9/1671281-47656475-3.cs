    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _windowTitleBar = "Hellooo";
        public MainWindow()
        {
            this.WindowTitleBar = "Hellooo";
            InitializeComponent();
        }
        public string WindowTitleBar
        {
            get { return _windowTitleBar; }
            set
            {
                _windowTitleBar = value;
                OnPropertyChanged("WindowTitleBar");
            }
        }
        void RefreshStatusBar()
        {
            this.WindowTitleBar = "Holaaa";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            RefreshStatusBar();
        }
    }
  
