    public partial class MainWindow:Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {                        
               textButton.Text = "Running...";
               string result = await DoIt();
               textButton.Text = result;
        }
        private async Task<string> DoIt()
        {
            await Task.Delay(3000);
            return "Finished...";
        }
    }
