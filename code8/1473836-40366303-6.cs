    public class TabItemContentConverter : IValueConverter
    {
        //  This is truly awful stuff. But it works. In this case. 
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var tabItemContent = (value as FrameworkElement).DataContext;
            var parent = value as DependencyObject;
            while (null != parent)
            {
                parent = VisualTreeHelper.GetParent(parent);
                var tc = parent as TabControl;
                if (tc != null)
                {
                    var tabItem = tc.Items.Cast<TabItem>().FirstOrDefault(ti => ti.Content == tabItemContent);
                    if (null != tabItem)
                    {
                        return tabItem.Header;
                    }
                }
            }
            return "Unknown";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
