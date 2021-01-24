    public class MyConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value as Song;
        }
    }
