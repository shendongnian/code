    public class DictConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IDictionary<string, string> dict = value as IDictionary<string, string>;
            string key = parameter as string;
            string s;
            if (dict != null && !string.IsNullOrEmpty(key) && dict.TryGetValue(key, out s))
                return s;
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
----------
    <TextBlock Text="{Binding Path=Dict, Converter={StaticResource conv}, ConverterParameter={x:Static local:DataNames.AxisX}}" />
