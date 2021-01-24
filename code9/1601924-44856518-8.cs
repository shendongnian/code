    class ColorStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string text = (string)value;
            return !string.IsNullOrWhiteSpace(text) ? text : DependencyProperty.UnsetValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
