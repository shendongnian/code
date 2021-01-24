    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    
        private async void OnCollectData(object sender, RoutedEventArgs e)
        {
            var data = await CollectDataAsync();
            HostControl.Content = new MyCustomGridControl(data);
        }
    
        private async Task<GridDataHolder> CollectDataAsync()
        {
            GridDataHolder result = null;
            await Task.Run(() =>
            {
                // Collect the logical data on the thread pool
                result = GetGridData();
            });
            return result;
        }
    }
