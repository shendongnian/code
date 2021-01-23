    public class ItemsVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IEnumerable itemCollection = value as IEnumerable;
            if (itemCollection != null)
            {
                foreach (PropertyItem propertyItem in itemCollection)
                {
                    if (propertyItem.Visibility == Visibility.Visible)
                    {
                        return true;
                    }
                }
            }
    
            return false;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
