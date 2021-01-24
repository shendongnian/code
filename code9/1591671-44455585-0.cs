    public partial class Window13 : Window, INotifyPropertyChanged
    {
        public Window13()
        {
            InitializeComponent();
        }
        private string _windowTitle = "default title...";
        public string WindowTitle
        {
            get { return _windowTitle; }
            set { _windowTitle = value; NotifyPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
