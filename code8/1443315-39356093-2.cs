    public class ImageConverter : IValueConverter
    {
        public object Convert(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            BitmapImage bitmap = null;
            var buffer = value as byte[];
            if (buffer != null)
            {
                using (var stream = new MemoryStream(buffer))
                {
                    bitmap = BitmapFrame.Create(
                        stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                }
            }
            return bitmap;
        }
        public object ConvertBack(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
