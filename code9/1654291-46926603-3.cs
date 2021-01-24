    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var backColor = Brushes.Transparent;
            if (value!=null && value.ToString().Equals("Process"))
            {
                backColor = Brushes.Green;
            }
            return backColor;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
