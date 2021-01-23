    public class MyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            IDictionary<string, string> dictionary = value as IDictionary<string, string>;
            string dictionaryValue;
            if (dictionary != null && dictionary.TryGetValue(parameter as string, out dictionaryValue))
            {
                return dictionaryValue;
            }
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }
    }
