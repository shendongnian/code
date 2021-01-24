    public class ValueToExponentialConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double d = (double)value;
    
            if (d == 0 || 0.0099 < d)
                return Math.Round(d, 3).ToString();
            else return d.ToString("0.#E+0");
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        { 
            throw new NotImplementedException();
        }
    
    }
