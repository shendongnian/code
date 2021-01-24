    public class BackConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var index = ((ItemsControl)values[1]).Items.IndexOf(values[0]);
            if (index % 2 == 0)
                return Brushes.Gray;
            return Brushes.White; 
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        } 
    }
