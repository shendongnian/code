    public class CanvasConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Canvas can = values[0] as Canvas;
            Button btn = values[1] as Button;
            Button btn0 = values[2] as Button;
            if (parameter.Equals("top"))
                return Canvas.GetTop(btn) + can.Children.IndexOf(btn0) * 25;
            else if (parameter.Equals("left"))
                return Canvas.GetLeft(btn) + 0;
            return null;
        } 
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        } 
    }
