    public class StringToNullableNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stringValue = value as string;
            if (stringValue == null) return value;
            if (targetType == typeof(int?))
            {
                int intValue;
                if (Int32.TryParse(stringValue, out intValue))
                {
                    return intValue;
                }
                return null;
            }
            return value;
        }
    }
