     public class StringToMailToConverer : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           if(value != null)
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    return "mailto:" + value.ToString();
                }
            }
            return string.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
