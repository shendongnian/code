    public class VisibilityToBoolConverter : IValueConverter
    { 
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == true)
                return Visibility.Visible;
            return Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((Visibility)value ==  Visibility.Visible)
                return true;
            return false;
        }
    }
