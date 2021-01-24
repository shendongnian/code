    public class DateTimeNullConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider) => this;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime)
                return value.ToString();
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = value as string;
            DateTime result;
            if (text != null && DateTime.TryParse(text, out result))
                return result;
            return null;
        }
    }
