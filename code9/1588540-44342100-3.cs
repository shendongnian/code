    public class QuadraticEquationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {            
            if(parameter.Equals("aValue") && value.ToString() != "")
                return value + "x^2 + ";
            else if(parameter.Equals("bValue") && value.ToString() != "")
                return value + "x + ";
            else
                return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
