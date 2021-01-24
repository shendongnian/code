    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        async void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window w = new ProgressWindow();
            w.Show();
            await Go; 
            w.Close();
        }
        async Task Go()
        {
            await Task.Delay(500);    
            MessageBox.Show("Completed!");
        }
    }
