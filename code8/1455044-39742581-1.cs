    public class ItemCountConverter : IValueConverter
    {
    
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            CollectionViewGroup group = (CollectionViewGroup)value;            
            ReadOnlyObservableCollection<object> items = group.Items;
            return items.Count;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
