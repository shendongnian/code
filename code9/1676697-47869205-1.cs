    public class TriggersToString : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) =>
            (values[0] as IList<Bot>)?.Count.ToString(); // first binding
        ...
    }
