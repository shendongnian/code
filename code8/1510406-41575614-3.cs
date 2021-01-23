    using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
    {
        IsolatedStorageFileStream fileStream = myIsolatedStorage.CreateFile("fileNameHere");
        BitmapImage bitmap = new BitmapImage();
        var stream = await DownloadFile(new Uri("http://someuri.com", UriKind.Absolute));
        bitmap.SetSource(stream);
        WriteableBitmap wb = new WriteableBitmap(bitmap);
        // Encode WriteableBitmap object to a JPEG stream.
        Extensions.SaveJpeg(wb, fileStream, wb.PixelWidth, wb.PixelHeight, 0, 85);
        fileStream.Close();
    }
