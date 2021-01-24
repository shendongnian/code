    public class IsCheckedConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool isChecked = (bool)values[0];
            List<string>[] lists = (List<string>[])values[1];
            
            if (isChecked == true)
            {
                return lists[0];
            }
            else
            {
                return lists[1];
            }
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }  
    }
