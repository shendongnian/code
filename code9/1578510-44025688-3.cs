    public class CultureConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                DateTime dateTime;
                if(DateTime.TryParse(value.ToString(), out dateTime))
                {
                    if(parameter != null)
                    {
                        return dateTime.ToString(parameter.ToString(), new CultureInfo(Translator.CurrentLanguage));
                    }
                    return dateTime.ToString(new CultureInfo(Translator.CurrentLanguage));
                }
                return null;
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
