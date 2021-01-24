    public class TupleDisplayNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var tuple = value as (Int32 Id, String Name)?;
            if (tuple == null)
                return null;
            return tuple.Value.Name;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
    <TextBlock Text="{Binding Converter={StaticResource TupleDisplayNameConverter}, Mode=OneWay}" />
