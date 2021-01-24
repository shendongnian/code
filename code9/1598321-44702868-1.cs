    public class StyleConverter : IMultiValueConverter {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            // take some caution here, because values can be null or DependencyProperty.UnsetValue in certain cases
            var enabled = (bool) values[0];
            var required = (bool) values[1];
            // choose style
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
