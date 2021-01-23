    var bitmap = new BitmapImage();
    using (var stream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
    {
        bitmap.BeginInit();
        bitmap.CacheOption = BitmapCacheOption.OnLoad;
        bitmap.StreamSource = stream;
        bitmap.EndInit();
        bitmap.Freeze();        
    }
    fileList.ItemImage = bitmap;
