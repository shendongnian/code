    public class TableConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //  I'm inferring that Measurement.Delta is Nullable<double>; if that's 
            //  not the case, change accordingly. Is it Object instead? 
            double? delta = (double?)values[0];
            double tol = (double)values[1];
            if (delta.HasValue && Math.Abs(delta.Value) < tol)
            {
                return "Green";
            }
            return "Red";
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
