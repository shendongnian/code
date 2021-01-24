    public class CountToBoolenConverter : IValueConverter
    {
        public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {            
            return (int)value != 0;
        }
        public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException ();
        }
    }
