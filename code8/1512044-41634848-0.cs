    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    
        public Dictionary<string, string> MyDict
        {
            get { return _MyDict; }
            set 
            {
                _MyDict = value;
                PropertyChanged?.(this, new PropertyChangedEventArgs("MyDict"));
            }         
        }
    }
