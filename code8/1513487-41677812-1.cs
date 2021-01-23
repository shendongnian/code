    private StorageFile storeFile;
    private IRandomAccessStream stream;
    private async void SavePhotoClicked(object sender, RoutedEventArgs e)
    {
        try
        {
            CameraCaptureUI capture = new CameraCaptureUI();
            capture.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            capture.PhotoSettings.CroppedAspectRatio = new Size(3, 5);
            capture.PhotoSettings.MaxResolution = CameraCaptureUIMaxPhotoResolution.HighestAvailable;
            storeFile = await capture.CaptureFileAsync(CameraCaptureUIMode.Photo);
            if (storeFile != null)
            {
                stream = await storeFile.OpenAsync(FileAccessMode.Read);
                var s = await KnownFolders.PicturesLibrary.CreateFileAsync(DateTime.UtcNow.ToString("yyyyMMddHHmmss") + ".jpg");
                using (var dataReader = new DataReader(stream.GetInputStreamAt(0)))
                {
                    await dataReader.LoadAsync((uint)stream.Size);
                    byte[] buffer = new byte[(int)stream.Size];
                    dataReader.ReadBytes(buffer);
                    await FileIO.WriteBytesAsync(s, buffer);
                }
            }
        }
        catch (Exception ex)
        {
            var messageDialog = new MessageDialog(ex.Message, "Unable to save now.");
            await messageDialog.ShowAsync();
        }
    }
