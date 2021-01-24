    public class MyCollectionConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var result = new ObservableCollection<ObjectB>();
            result.Add(((ObjectA)value).CurrentChild);
            result.Add(((ObjectA)value).PreviousChild );
            return result;
       }
       public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
       {
           throw new NotImplementedException();
       }
    }
