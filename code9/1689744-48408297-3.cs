    public class InRangeConverter : IMultiValueConverter
    {
        private static readonly SolidColorBrush SelectedBrush = 
            new SolidColorBrush(Color.FromArgb(0xFF, 0xF7, 0x8A, 0x09));
        private static readonly SolidColorBrush UnselectedBrush =
            new SolidColorBrush(Color.FromArgb(0x3F, 0xF7, 0x8A, 0x09));
        private static readonly object[] ConvertBackResult =
            { DependencyProperty.UnsetValue };
        public object Convert(object[] values, Type type, object p, CultureInfo c)
        {
            if (values?.Length == 3)
            {
                var lower = values[0] as double?;
                var value = values[1] as double?;
                var upper = values[2] as double?;
                if (value == null)
                {
                    var stringValue = values[1]?.ToString();
                    if (stringValue != null && double.TryParse(stringValue, out var d))
                        value = d;
                }
                if (value >= lower && value <= upper)
                    return SelectedBrush;
                return UnselectedBrush;
            }
            return Brushes.Gray;
        }
        public object[] ConvertBack(object value, Type[] types, object p, CultureInfo c)
        {
            return ConvertBackResult;
        }
    }
