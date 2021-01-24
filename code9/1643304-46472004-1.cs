    public class EqualityMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //  Return true if we have fewer than two values, 
            //  or if we have at least two, and they're all equal.
            return values.Length < 2 || values.Skip(1).All(v => values[0] == v);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
