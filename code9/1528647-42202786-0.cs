    namespace WpfApplication3
    {
        public class RowNumberConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                return ((values[0] as DataGridRow).GetIndex() + 1).ToString();
            }
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
