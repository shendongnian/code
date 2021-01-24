    [ValueConversion(typeof(bool), typeof(double))]
    public class BoolToMaxConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value == true) ? double.MaxValue : 0d;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {    // Don't need any convert back
            return null;
        }
    }
