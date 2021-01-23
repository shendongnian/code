        using Windows.Foundation; 
        using Windows.Networking.BackgroundTransfer;
        using Windows.Storage.Pickers;
        using Windows.Storage;
        private async void StartUpload_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Uri uri = new Uri(serverAddressField.Text.Trim());
                FileOpenPicker picker = new FileOpenPicker();
                picker.FileTypeFilter.Add("*");
                StorageFile file = await picker.PickSingleFileAsync();
                BackgroundUploader uploader = new BackgroundUploader();
                uploader.SetRequestHeader("Filename", file.Name);
                UploadOperation upload = uploader.CreateUpload(uri, file);
                // Attach progress and completion handlers.
                HandleUploadAsync(upload, true);
            }
            catch (Exception ex)
            {
                LogException("Upload Error", ex);
            }
        }
