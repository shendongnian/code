    <Label Text="{Binding FormattedJpegQualityValue, 
                  Converter={StaticResource ZeroesConverter}}"}" />
    // obviously, following is not in your xaml.
    public class ZeroesConverter : IValueConverter
    {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                    // put logic here. 
                    // convert int to string, look at length, append zeroes, or use the string formatter if you want
            }
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                    // throw some exception. you don't need this
            }
    }
