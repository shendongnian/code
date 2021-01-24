    public class CultureConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if(values[0] != DependencyProperty.UnsetValue && values[1] != DependencyProperty.UnsetValue)
            {
                decimal balance = System.Convert.ToDecimal(values[0]);
                string c = values[1] as string;
                return balance.ToString("C", CultureInfo.GetCultureInfo(c));
            }
            return Binding.DoNothing;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
