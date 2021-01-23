    public class MyCustomDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return ((DateTime)value).ToString("dd/MM/yyyy hh:mm:ss tt", culture);
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DateTime.ParseExact((string)value, "dd/MM/yyyy hh:mm:ss tt", culture);
        }
    }
