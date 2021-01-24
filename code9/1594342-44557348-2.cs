    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }
        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Put your rules here - Example rejects the period key
            if (e.Key == Key.OemPeriod)
                e.Handled = true;
        }
    }
