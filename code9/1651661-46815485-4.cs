    public ImageSource ImageSource
    {
        get
        {
            ImageSource imageSource;
            using (var stream = new MemoryStream())
            {
                ...
                imageSource = BitmapFrame.Create(
                    stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
            Method();
            return imageSource;
        }
    }
