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
                    imageSource = BitmapFrame.Create(
                        stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                }
                Method();
            }
            return imageSource;
        }
    }
