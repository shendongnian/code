    public void HandleImageFileOperations(StorageFile file)
    {
        if (file != null)
        {
             //converts the StorageFile to IRandomAccessStream
             var stream = await file.OpenAsync(FileAccessMode.Read);
             //creates the stream to an Image just in-case you want to show it
             var image = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
             image.SetSource(stream);
             //creates the image into byte array just in-case you need it to store the image
             byte[] bitmapImageBytes = null;
             var reader = new Windows.Storage.Streams.DataReader(stream.GetInputStreamAt(0));
             bitmapImageBytes = new byte[stream.Size];
             await reader.LoadAsync((uint)stream.Size);
             reader.ReadBytes(bitmapImageBytes);
        }
    }
