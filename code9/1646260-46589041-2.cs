    public ImageSource ImageSrc
    {
        get
        {
            ImageSource image;
            using (var stream = new MemoryStream(GetImageAsByteArray()))
            {
                image = BitmapFrame.Create(
                    stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
            SplashScreenEnabled = false;
            return image;
        }
    }
    public bool SplashScreenEnabled { get; set; } // firing PropertyChanged omitted
