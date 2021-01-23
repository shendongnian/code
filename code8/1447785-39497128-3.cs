    public class FilenameToImageConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            string uri = value as string;
            if (uri != null && File.Exists(uri)) {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = new Uri(uri);
                image.DecodePixelWidth = 1920; // should be enough, but you can experiment
                image.EndInit();
                return image;
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotSupportedException();
        }
    }
