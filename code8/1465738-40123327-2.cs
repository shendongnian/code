    public class BoolToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool? b = (bool?)value;
            if (b == true)
                return new SolidColorBrush(Colors.BlueViolet);
            return new SolidColorBrush(Colors.Transparent);
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
