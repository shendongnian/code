    namespace WpfApp2
    {
        public class MyConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                Coordinate c = value as Coordinate;
                if(c != null)
                {
                    return c.ToString(parameter as string);
                }
                return value;
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotSupportedException();
            }
        }
    }
----------
    <Grid xmlns:local="clr-namespace:WpfApp2">
        <Grid.Resources>
            <local:MyConverter x:Key="conv" />
        </Grid.Resources>
        <TextBlock Text="{Binding ElementName=mw, Path=DataContext.Latitude, Converter={StaticResource conv}, ConverterParameter='DMS'}"/>
    </Grid>
