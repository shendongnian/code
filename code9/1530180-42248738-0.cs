    public class EnumToStringConv : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return value;
            return (X509FindType)Enum.Parse(typeof(X509FindType), value.ToString(), true);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((X509FindType)value).ToString();
        }
    }
