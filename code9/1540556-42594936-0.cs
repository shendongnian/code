    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            ExampleCommand = new RelayCommand<object>(x => { throw new ApplicationException(); });
        }
        private ICommand _exampleCommand;
        public ICommand ExampleCommand
        {
            get { return _exampleCommand; }
            set { _exampleCommand = value; NotifyPropertyChanged(); }
        }
        private void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.Assert(exampleButton.DataContext == this);
            Debug.Assert(exampleButton.Command == ExampleCommand); //<-- FAIL
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
