    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private string _language = "EN";
        public string TheLanguage
        {
            get { return _language; }
            set { _language = value; NotifyPropertyChanged(); }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TheLanguage = TheLanguage == "EN" ? "ES" : "EN";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
