    public class DoubletoGridConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var n = (double) value;
            return new GridLength(n);
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
