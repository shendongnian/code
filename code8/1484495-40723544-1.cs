    var tempBitmapImage = new BitmapImage();
    using (var stream = new FileStream(
        _fileList[_fileCounter].FileName, FileMode.Open, FileAccess.Read))
    {
        tempBitmapImage.BeginInit();
        tempBitmapImage.CacheOption = BitmapCacheOption.OnLoad;
        tempBitmapImage.StreamSource = stream;
        tempBitmapImage.EndInit();
    }
    tempImage.Source = tempBitmapImage;
