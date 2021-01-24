    public sealed class CustomColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null && (bool)value)
            {
                return new SolidColorBrush(Colors.Red);
            }
            else
            {
                return new SolidColorBrush(Colors.Yellow);
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
