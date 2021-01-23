    public class UriConverterNormal : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string relativepath = value as String;
            BitmapImage bi = new BitmapImage();
            bi.UriSource = new Uri(relativepath.Trim(), UriKind.Absolute);
            return bi;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
