    public class InvertBoolenConverter : IValueConverter
    {
        public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool) 
            {
                return !(bool)value;
            }
            return value;
    }
        public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
        throw new NotImplementedException ();
        }
    }
