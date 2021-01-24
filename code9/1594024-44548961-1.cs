    public class MyCustomConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, 
            object parameter, CultureInfo culture)
        {
            
            var myCountry = //Add your code to look up the country name linked to the given 'CountryId' (value) and return the name
            return myCountry != null ? myCountry.CountryName : string.Empty;
        }
        public object ConvertBack(object value, Type targetType, 
            object parameter, CultureInfo culture)
        {
            //Not needed with a OneWay binding
        }
    }
