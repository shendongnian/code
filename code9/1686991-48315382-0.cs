    public class MultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {  
            if (values.Length != 3) throw new ArgumentException("Should be 3 params");
            if (!(values[2] is FrameworkElement element)) return values[1];
    
            if (!(bool)values[0])
            {
                element.Tag = "Value need to be changed.";
                return values[1];
            }
    
            if (element.Tag.Equals("Value changed.")) return values[1];
            var res = !(bool)(values[1] ?? true);
            element.Tag = "Value changed.";
            return res;
        }
    
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
