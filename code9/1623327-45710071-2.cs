    public class MinConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double result = double.NaN;
            if (values != null)
            {
                try
                {
                    result = values.Cast<double>().Aggregate(double.PositiveInfinity, (a, b) => Math.Min(a, b));
                }
                catch (Exception)
                {
                    result = double.NaN;
                }
            }
            return result;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
