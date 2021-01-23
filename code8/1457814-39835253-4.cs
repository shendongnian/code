        public class PropertyInfoValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            PropertyInfo propertyInfo = values[0] as PropertyInfo;
            return propertyInfo.GetValue(values[1]);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
