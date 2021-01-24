    public class MultiIcommandParameterConverter : IMultiValueConverter
    {        
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values[0] + "," + values[1];
        }
    
        object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
