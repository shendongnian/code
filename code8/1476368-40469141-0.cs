    public class NamedPropertyValueConverter : IMultiValueConverter
    {
        public object Convert(
            object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var sourceObj = values[0];
            var propName = values[1].ToString();
            var propInfo = sourceObj.GetType().GetProperty(propName);
            return propInfo.GetValue(sourceObj);
        }
        public object[] ConvertBack(
            object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
