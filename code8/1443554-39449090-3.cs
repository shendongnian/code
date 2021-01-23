    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;
        }
        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            listView1.Items.Add(string.Format("{0} : Power mode changed = {1}", DateTime.Now, e.Mode));
        }
    }
