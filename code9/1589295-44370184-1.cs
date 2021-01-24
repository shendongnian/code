    public class AreAllTrueMultiValueConverter: IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, 
               object parameter, System.Globalization.CultureInfo culture)
        {
            return values.OfType<bool>().All();
        }
        public object[] ConvertBack(object value, Type[] targetTypes, 
               object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }
