    public class PercentageConverter: IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length != 3)
                return 0;
            if (
                Equals(DependencyProperty.UnsetValue, values[0]) ||
                Equals(DependencyProperty.UnsetValue, values[1]) ||
                Equals(DependencyProperty.UnsetValue, values[2])
            )
                return 0;
            double value =  (double)values[0];
            double min = (double)values[1];
            double max = (double)values[2];
            return (value - min) / (max - min);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
