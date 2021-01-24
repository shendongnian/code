    public class SelectedCalcDataConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var items = values[0] as IEnumerable<CalcData>;
            var selectedId = values[1] as int?;
            if (items != null)
            {
                var result = items.FirstOrDefault(x => x.Condition.Id == selectedId);
                return result;
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
