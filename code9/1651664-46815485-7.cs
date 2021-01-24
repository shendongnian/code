    private ImageSource imageSource;
    public ImageSource ImageSource
    {
        get
        {
            if (imageSource == null)
            {
                using (var stream = new MemoryStream())
                {
                    ...
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();
                    bitmap.Freeze(); // necessary for async binding
                    imageSource = bitmap;
                }
                Method();
            }
            return imageSource;
       }
    }
