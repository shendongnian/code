    public class SumConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            double _Sum = 0;
            if (values == null)
                return _Sum;
            foreach (var item in values)
            {
                double _Value;
                if (double.TryParse(item.ToString(), out _Value))
                    _Sum += _Value;
            }
            return _Sum;
        }
    
        public object[] ConvertBack(object value, Type[] targetTypes,
            object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
