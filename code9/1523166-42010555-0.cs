    public class HeightToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var gridHeight = System.Convert.ToDouble(value);
    
            return gridHeight < 200 ? Visibility.Collapsed : Visibility.Visible;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
