    public class MyMultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // perform your conversion here and return the final value
            // so which value both textBoxes need to have that you return `true` so
            // that `button1.Enabled` gets set to `true`
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
