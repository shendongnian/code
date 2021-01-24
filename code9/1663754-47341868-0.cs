    public sealed partial class MainPage : Page
    {
        private DataTransferManager dataTransferManager;
        private IReadOnlyList<StorageFile> filesToShare;
        public MainPage()
        {
            this.InitializeComponent();
            dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += DataTransferManager_DataRequested;
        }
        private void DataTransferManager_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            DataRequest request = args.Request;
            request.Data.Properties.Title = "Share";
            request.Data.Properties.Description = "Share the selected document";
            request.Data.SetStorageItems(filesToShare);
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.FileTypeFilter.Add("*");
            filesToShare = await openPicker.PickMultipleFilesAsync();
            DataTransferManager.ShowShareUI();
        }
    }
