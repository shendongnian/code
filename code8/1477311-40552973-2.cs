    public class BooleanWidthConverter : IValueConverter
    {
        private static GridLength star = new GridLength(1, GridUnitType.Star);
        private static GridLength zero = new GridLength(0, GridUnitType.Pixel);
    
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool boolValue = (bool)value;
    
            return boolValue ? star : zero;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
