    public class PathToTooltipConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            ListBoxItem item = values[0] as ListBoxItem;
            string tooltipMemberPath = values[1] as string;
            if (tooltipMemberPath == null)
                return null;
            MyListBoxItemClass itemClass = (MyListBoxItemClass)item.DataContext;
            return itemClass.GetType().GetProperty(tooltipMemberPath).GetValue(itemClass, null);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
