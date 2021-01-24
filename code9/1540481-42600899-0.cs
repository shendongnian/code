    private static async Task<BitmapImage> ConvertToBitmap(string filename)
    {
        StorageFile file = await KnownFolders.DocumentsLibrary.GetFileAsync(filename);
        return await LoadImage(file);
    }
    private static async Task<BitmapImage> LoadImage(StorageFile file)
    {
        BitmapImage bitmapImage = new BitmapImage();
        FileRandomAccessStream stream = (FileRandomAccessStream)await file.OpenAsync(FileAccessMode.Read);
        bitmapImage.SetSource(stream);
        return bitmapImage;
    }
