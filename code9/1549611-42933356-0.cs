    public class SelectionModeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                if (value.ToString() == (string)parameter)
                    return true;
            }
            return false;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((bool)value) ? parameter : Binding.DoNothing;
        }
    }
