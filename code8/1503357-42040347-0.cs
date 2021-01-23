    <TextBox Name="sample" Visibility="{Binding JobStatus,Converter={staticResource BooleanToVisibilityConverter}" />
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }
    }
