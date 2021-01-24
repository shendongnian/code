    public class LogTypeBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color color = Colors.Black;
            
            switch ((LogType)value)
            {
                case LogType.Start:
                    color = Colors.DodgerBlue;
                    break;
                case LogType.Stop:
                    color = Colors.OrangeRed;
                    break;
                case LogType.Info:
                    color = Colors.Blue;
                    break;
                case LogType.Success:
                    color = Colors.Green;
                    break;
                case LogType.Error:
                    color = Colors.Red;
                    break;
            }
            return new SolidColorBrush(color);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
