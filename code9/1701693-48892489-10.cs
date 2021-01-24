    public ImageSource LoadImage(string filename)
    {
        using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.DecodePixelWidth = 200;
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.StreamSource = stream;
            bitmap.EndInit();
            bitmap.Freeze();
            return bitmap;
        }
    }
