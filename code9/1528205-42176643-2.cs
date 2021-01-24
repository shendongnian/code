    public class IntDecConverter : IValueConverter
    {
        public object Convert(Object value, Type type, Object parameter, CultureInfo CultureInfo)
        {
            return System.Convert.ToDecimal(value).ToString();
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplemnentedException();
        }
    }
