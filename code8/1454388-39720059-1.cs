    public class VisibilityTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int actualType = parameter == null ? 0 : System.Convert.ToInt32(parameter);
            int compareType = value == null ? 0 : System.Convert.ToInt32(value);
    
            if (actualType == compareType)
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
