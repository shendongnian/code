    public class MultiplyConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.OfType<double>().Aggregate(1.0, (current, t) => current * t);
        }
        // ConvertBack omitted...
    }
