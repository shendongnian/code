    public class IntDecConverter : IValueConverter
    {
        public object Convert(Object value, Type type, Object parameter, CultureInfo cultureInfo)
        {
            if (value == null) return value;
            char[] characters = value.ToString().ToCharArray();
            if (characters[characters.Length - 1].ToString() != ".")
            {
                System.Convert.ToDecimal(value).ToString();
            }
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
