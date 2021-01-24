    public class Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string shownName = value as string;
            if (!string.IsNullOrEmpty(shownName) && shownName.Length > 35)
                return shownName.Substring(0, 35) +  "...";
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
