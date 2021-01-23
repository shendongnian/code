    namespace AppConverters    
    public class List2StringConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, 
                object parameter, CultureInfo culture)
            {
                List<int> listNumbers = value as List<int>;
                // separator : , - / ... or white space
        		return string.join("separator",listNumbers);
            }
         
            public object ConvertBack(object value, Type targetType, 
                object parameter, CultureInfo culture)
            {
                // To Do 
            }
        }
