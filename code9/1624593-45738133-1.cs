    public class HeightConverter : IMultiValueConverter
    {
       public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
       {
            if (values == null || parameter == null || values[0] == null || values[1] == null)
            {
                return null;
            }
            
            var currentWindowHeight = double.Parse(values[0].ToString());
            var currentMinHeight = double.Parse(values[1].ToString());
            var currentTopWindowHeight = double.Parse(parameter.ToString());
            var newHeight = currentWindowHeight - currentTopWindowHeight;
            
            if (newHeight < currentMinHeight)
                newHeight = currentMinHeight;
            return newHeight;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
