    public class MultiConverter2 : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string SecondLabelContent = values[0] as string;
            string SecondLabelFormatContent = values[1] as string;
            return string.Format(SecondLabelFormatContent, SecondLabelContent);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
