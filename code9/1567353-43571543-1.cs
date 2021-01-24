     public class FirstToSecondConverter : IValueConverter
     {
        public object Convert(object value, Type targetType, 
            object parameter, CultureInfo culture)
        {
             // Do the conversion here from first to second value
        }
 
        public object ConvertBack(object value, Type targetType, 
             object parameter, CultureInfo culture)
        {
             // Do the conversion from second to first value
        }
    }
