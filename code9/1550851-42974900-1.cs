    <Window.Resources>
        <local:YourConverter x:Key="conv" />
    </Window.Resources>
    ...
    <TextBox Text="{Binding Path=Option.Value, NotifyOnSourceUpdated=True, Coverter={StaticResource conv}}" / >
----------
    public class YourConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //convert the int to a string:
            return value.ToString();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //convert the string back to an int here
            return int.Parse(value.ToString());
        }
    }
