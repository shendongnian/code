    public class ForfaitQuantityConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
             string stringValue = value as string;
            if (string.IsNullOrWhiteSpace(stringValue) || stringValue.Equals("0"))
            {
                return string.Empty;
            }
            return value;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
    
        }
    }
