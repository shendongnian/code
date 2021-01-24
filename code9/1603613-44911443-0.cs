    public class MyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if ((string)value == "true")
                return new SolidColorBrush(Colors.Green);
            else
                return new SolidColorBrush(Colors.Red);
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
