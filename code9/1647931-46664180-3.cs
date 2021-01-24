    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<myItem> _items;
        public ObservableCollection<myItem> Item
        {
            get { return _items; }
            set { _items = value; NotifyPropertyChanged(); }
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnAppend_Click(object sender, RoutedEventArgs e)
        {
            Item = new ObservableCollection<myItem>() { new myItem() { Username = "Prabhat" } };
        }
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
