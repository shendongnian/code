        [ValueConversion(typeof(object), typeof(string))]
    public class StringFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
        {
            string str = value.ToString();
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            else
            {
                if (str.Length >= 35)
                {
                    return str.Substring(0, 35);
                }
                else
                {
                    return str;
                }
            }
        }
        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
