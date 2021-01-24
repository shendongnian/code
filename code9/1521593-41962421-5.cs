    public class TimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return new DateTimeOffset(((DateTime)value).ToUniversalTime());
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return ((DateTimeOffset)value).DateTime;
        }
    }
