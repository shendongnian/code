    public partial class MainWindow : INotifyPropertyChanged
    {
        private bool _flag1;
        private bool _flag2;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Flag1 = true;
            Flag2 = false;
        }
        public bool Flag1 {
            get {
                return _flag1;
            }
            set {
                _flag1 = value;
                OnPropertyChanged();
            }
        }
        public bool Flag2 {
            get {
                return _flag2;
            }
            set {
                _flag2 = value;
                OnPropertyChanged();
            }
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
            Flag1 = !Flag1;
            Flag2 = !Flag2;
        }
    }
