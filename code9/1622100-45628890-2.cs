    public class BoolToMyEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is mActive)
            {
                return (mActive)value == 0 ? false : true;
            }
    
            return false;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                return (bool)value ? mActive.Toggled : mActive.NotToggled;
            }
    
            return mActive.NotToggled;
        }
    }
