        public class PercentageConverter : IValueConverter
        {
            public object Convert(object value,
                Type targetType,
                object parameter,
                System.Globalization.CultureInfo culture)
            {
                double _value = Double.Parse(value.ToString(), CultureInfo.CurrentCulture);
                double _parameter = Double.Parse(parameter.ToString(), culture);
                return _value * _parameter;
            }
            public object ConvertBack(object value,
                Type targetType,
                object parameter,
                System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
