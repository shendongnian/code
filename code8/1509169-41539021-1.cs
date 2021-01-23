    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private SolidColorBrush backgroundColor = new SolidColorBrush(Colors.Black);
        public SolidColorBrush BackgroundColor
        {
            get { return backgroundColor; }
            set
            {
                if (backgroundColor == value)
                    return;
                backgroundColor = value;
                RaisePropertyChanged(nameof(backgroundColor));
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            // Make sure to set the DataContext to this!
            DataContext = this;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Change the color through the property
            if (BackgroundColor.Color == Colors.Black)
                BackgroundColor = new SolidColorBrush(Colors.Transparent);
            else
                BackgroundColor = new SolidColorBrush(Colors.Black);
        }
    }
