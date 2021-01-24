    public class SignColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var input = (item)value;
            if (input != null)
            {
                int item1 = int.Parse(input.Item1);
                int item2 = int.Parse(input.Item2);
                //Your logic here
                return Brushes.Red;
            }            
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
