    public class EnumToStringConverter : IValueConverter
    { 
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Enum.Parse(typeof(MyTypes), value.ToString());
        }
    }
