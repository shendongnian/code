    public class DataUrlConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var data = (string) value;
            var base64Data = Regex.Match(data, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
            var binData = System.Convert.FromBase64String(base64Data);
            var image = new BitmapImage();
            using (var mem = new MemoryStream(binData))
            {
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
