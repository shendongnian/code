    public class conv1 : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Model m = values[0] as Model;
            PropertyInfo pi = values[1] as PropertyInfo;
            if (m != null && pi != null)
            {
                return pi.GetValue(m);
            }
            return Binding.DoNothing;
        } 
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        } 
    }
