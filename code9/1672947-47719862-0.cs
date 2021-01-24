    private string _backgroundImageFilePath;
    public string BackgroundImageFilePath {
        get { return _backgroundImageFilePath; }
        set {
            SetNotify(ref _backgroundImageFilePath, value);
            try {
                BackgroundImage = new BitmapImage(new Uri(BackgroundImageFilePath));
            }
            catch (FileNotFoundException) {
                BackgroundImage = ImageNotFoundBitmapImage;
            }
            catch (Exception) {
                BackgroundImage = ImageInvalidBitmapImage;
            }
            ThrusterImageMaximumScale = BackgroundImage.Width / (2 * RovIllustrationThruster.VerticalThrusterBitmapImage.Width);
            ThrusterImageMaximumScale = Math.Round(ThrusterImageMaximumScale, 1);
            if (ThrusterImageScale > ThrusterImageMaximumScale) {
                ThrusterImageScale = ThrusterImageMaximumScale;
            }
            ConfigurationHandler.IsDirty = true;
        }
    }
