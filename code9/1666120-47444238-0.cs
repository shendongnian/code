    public sealed partial class MainPage : Page
    {
        private DataTransferManager dataTransferManager;
        public MainPage()
        {
            this.InitializeComponent();
            dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += DataTransferManager_DataRequested;
        }
        private void DataTransferManager_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            DataRequest request = args.Request;
            request.Data.Properties.Title = "Share the App";
            request.Data.Properties.Description = "This App in Windows Store";
            request.Data.SetWebLink(new Uri("https://www.microsoft.com/en-us/store/p/netflix/9wzdncrfj3tj"));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataTransferManager.ShowShareUI();
        }
    }
