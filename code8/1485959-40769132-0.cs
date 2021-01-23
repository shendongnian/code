    public class HighScoreToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var isBiggest = (bool)value;
            var color = isBiggest ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.Yellow);
            return color;
        }
    public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var color = value as SolidColorBrush;
            if (color != null)
            {
                return color == new SolidColorBrush(Colors.Red);
            }
            return false;
        }
    }
