    public class MyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, 
                System.Globalization.CultureInfo culture)
        {
            var tabIndex = int.Parse(value.ToString());
    		return tabIndex + 1;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, 
                System.Globalization.CultureInfo culture)
        {
            //don't needed
        }
    }
