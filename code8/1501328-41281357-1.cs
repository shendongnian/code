    public class ItemsToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var items = value as IEnumerable;
            if (items != null)
            {
                // note: items may contain the InsertRow item, which is of different type than the existing items.
                // so the items collection needs to be filtered for existing items before casting and reading the property
                var items2 = items.Cast<object>();
                var items3 = items2.Where(x => x is MyItemType).Cast<MyItemType>();
                return string.Join(Environment.NewLine, items3.Select(x => x.UNIQUEPART_ID));
            }
            return string.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new InvalidOperationException();
        }
    }
