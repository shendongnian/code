    namespace WpfApplication1
    {
        public class MultiConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                int CurrentNumber = (int)values[0];
                object content = values[1];
                return CurrentNumber.ToString() == content.ToString();
            }
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotSupportedException();
            }
        }
    }
