    public ImageSource ImageSource
    {
        get
        {
            BitmapImage bitmap = new BitmapImage();
            using (var stream = new MemoryStream())
            {
                ...
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = stream;
                bitmap.EndInit();
            }
            bitmap.Freeze(); // necessary for async binding
            Method();
            return bitmap;
        }
    }
