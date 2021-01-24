    public ImageSource LoadImageSourceFromBytes(byte[] imageBytes)
    {
        BitmapImage bitmapImage = new BitmapImage();
        using (MemoryStream imageStream = new MemoryStream(imageBytes))
        {
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = imageStream;
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();
        }
        bitmapImage.Freeze();
        return bitmapImage;
    }
