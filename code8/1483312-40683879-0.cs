    public class DecimalToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // convert here
            // value is your binding - use it if you can
            // parameter is the additional parameter that you can pass in but don't need to.
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value; // who cares?
        }
    }
