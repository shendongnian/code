    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Command = new RelayCommand(Action);
            Text = "Testing... Testing... 1, 2, 3,...";
        }
    }
