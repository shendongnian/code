    public class ColorConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var input = int.Parse(value.ToString());
                switch (input)
                {
                    case 1:
                        return Brushes.LightGreen;
                    case 2:
                        return Brushes.LightBlue;
                    case 3:
                        return Brushes.Yellow;
                    default:
                        return DependencyProperty.UnsetValue;
                }
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
