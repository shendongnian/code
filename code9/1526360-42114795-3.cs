    public partial class UserControl1 : UserControl, INotifyPropertyChanged
    {
        public UserControl1()
        {
            InitializeComponent();
            Loaded += (s, e) => resizeMe();
        }
        public void resizeMe()
        {
            TheFontSize = 40.0;
            TheForeground = Brushes.Red;
        }
        private double _fontSize;
        public double TheFontSize
        {
            get { return _fontSize; }
            set { _fontSize = value; OnPropertyChanged(); }
        }
        private Brush _foreGround;
        public Brush TheForeground
        {
            get { return _foreGround; }
            set { _foreGround = value; OnPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
