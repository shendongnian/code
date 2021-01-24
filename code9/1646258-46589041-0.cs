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
            Application.Current.Dispatcher.Invoke(() => SplashScreenEnabled = false);
            return image;
        }
    }
    public bool SplashScreenEnabled { get; set; } // firing PropertyChanged omitted
