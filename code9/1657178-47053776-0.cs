    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Closing += MainWindow_Closing;
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            if (MessageBox.Show("Do you want to close?", "", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
                Environment.Exit(0);
        }
    }
