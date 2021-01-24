    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Hellooo";
        }
        void RefreshStatusBar()
        {
            this.Title = "Holaaa";
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            RefreshStatusBar();
        }
    }
