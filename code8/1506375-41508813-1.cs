    public class DoubleToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return ((double) value).ToString("0.0", System.Globalization.CultureInfo.InvariantCulture);
        }
        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            double doubleValue;
            if (double.TryParse(value.ToString().Replace(',', '.'), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture,
                out doubleValue))
            {
                return doubleValue;
            }
            if (parameter != null && parameter is double)
                return (double)parameter;
            return 0.0;
        }
    }
