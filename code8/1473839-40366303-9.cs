    public class TabItemHeaderConverter : IMultiValueConverter
    {
        //  This is pretty awful, but nobody promised life would be perfect. 
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var tc = values[0] as TabControl;
            var tabItemContent = values[1];
            var tabItem = tc.Items.Cast<TabItem>().FirstOrDefault(ti => ti.Content == tabItemContent);
            if (null != tabItem)
            {
                return tabItem.Header;
            }
            return "Unknown";
        }
        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
