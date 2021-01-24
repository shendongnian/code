    public partial class MainWindow : Window
    {
        // My window object
        Screen win = new Screen();
        public MainWindow()
        {
            InitializeComponent();
            win.Show();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Simple toggle action
            if (win.myText.IsEnabled == true)
                win.myText.IsEnabled = false;
            else
                win.myText.IsEnabled = true;
        }
    }
