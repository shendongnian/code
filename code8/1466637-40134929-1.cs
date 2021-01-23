    public class ItemsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ReadOnlyObservableCollection<object> items = value as ReadOnlyObservableCollection<object>;
            if (items == null) throw new ArgumentNullException(nameof(items));
    
            DateTime latestOrderDate = items.Max(x => x.OrderDate);
            return latestOrderDate;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
